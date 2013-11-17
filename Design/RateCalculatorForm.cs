using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Design.Infrastructure;
using DevExpress.XtraEditors;

namespace Design
{
    public partial class RateCalculatorForm : UserControl
    {
        private Dictionary<int, string> parameters;
        private BindingList<Formula> formulas;
        private Dictionary<int, int> modifiedObjects;
        private Dictionary<int, int> modifiedParams;
        private BindingList<FormulaParameter> formParameters;
        private List<TestValue> testValues;
        
        public RateCalculatorForm()
        {
            InitializeComponent();
            closeButton.Click += OnCloseButtonClick;
            saveButton.Click += OnSaveButtonClick;
            testButton.Click += OnTestButtonClick;

            parameters = new Dictionary<int, string>();
            foreach (object[] d in DataHelper.GetParameters())
            {
                parameters.Add((int)d[0], (string)d[1]);
            }
            repositoryItemComboBox1.Items.Add(string.Empty);
            repositoryItemComboBox1.Items.AddRange(parameters.Values.OrderBy(v => v).ToArray());
            formulas = new BindingList<Formula>(DataHelper.GetFormulas());
            gridRateList.DataSource = formulas;
            modifiedObjects = new Dictionary<int, int>();
            modifiedParams = new Dictionary<int, int>();
            viewRateList.CustomDrawCell += (_,e) => OnCustomDrawCell(false, e);
            viewRateList.CellValueChanged += OnCellValueChanged;
            viewRateList.FocusedRowChanged += OnFocusedRowChanged;

            viewRateParams.CustomDrawCell += (_, e) => OnCustomDrawCell(true, e);
            viewRateParams.CellValueChanged += OnParamCellValueChanged;

            if (formulas.Count > 0)
            {
                viewRateList.SelectRow(0);
                formParameters = new BindingList<FormulaParameter>(formulas.First().Parameters);
                tbFormulaExp.Text = formulas.First().Expression;
            }
            else
            {
                formParameters = new BindingList<FormulaParameter>();
                tbFormulaExp.Text = string.Empty;
            }
            testCalcValue.Text = string.Empty;
            gridRateParams.DataSource = formParameters;
            validButton.Click += OnValidButtonClick;
            tbFormulaExp.TextChanged += OnTextChanged;
            testValues = new List<TestValue>();
        }

        private void OnTestButtonClick(object sender, EventArgs e)
        {
            var r = new Random();
            var f = (Formula)viewRateList.GetFocusedRow();
            if (f == null)
            {
                MessageBox.Show("Формула не определена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            testValues.Clear();
            FormulaParameter[] param = null;
            using (var oleCon = DataHelper.OpenOrCreateDb())
            {
                param = DataHelper.GetFormulaParameters(f.Id, oleCon).ToArray();
                testValues.AddRange(param.Select(p => new TestValue()
                                        {
                                            ParamName = p.Code,
                                            ParamValue = p.TypeId == 0 ? p.Value : r.Next(1000)
                                        }));
            }
            gridTestValues.DataSource = new BindingList<TestValue>(testValues);
            gridTestValues.Refresh();
            var ta = testValues.Select(t => new object[]{t.ParamName, t.ParamValue}).ToArray();
            string t1 = RatesFormulaProcessor.PresentationDemo(f.Expression, param, ta);
            decimal result = RatesFormulaProcessor.Calculate(f.Expression, param, ta);
            testCalcValue.Text = t1 + " = " + result;
        }

        private void OnValidButtonClick(object sender, EventArgs e)
        {
            var formula = (Formula)viewRateList.GetFocusedRow();
            if (formula == null) {
                   MessageBox.Show("Формула не определена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
            }
            var result = RatesFormulaProcessor.Validate(formula.Expression, DataHelper.GetFormulaParameters(formula.Id, DataHelper.OpenOrCreateDb()).ToArray());
            if (result == null || result.Length == 0)
            {
                MessageBox.Show("Проверка успешно завершена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var s = "Формула содержи ошибки:\r\n";
                foreach (var d in result)
                {
                    s += d + "\r\n";
                }
                MessageBox.Show(s, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var f = (Formula)viewRateList.GetRow(e.PrevFocusedRowHandle);
            if (modifiedParams.Count > 0)
            {
                foreach(var p in modifiedParams) {
                    if (p.Value == 1)
                    {
                        DataHelper.RemoveFormulaParameter(((FormulaParameter)viewRateParams.GetRow(p.Key)).Id);
                    }
                    else
                    {
                        DataHelper.SaveFormulaParameter((FormulaParameter)viewRateParams.GetRow(p.Key), f.Id);
                    }
                }
                MessageBox.Show("Не сохраненные данные были сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modifiedParams.Clear();
            }

            f = (Formula)viewRateList.GetRow(e.FocusedRowHandle);
            if (f != null)
            {
                formParameters = new BindingList<FormulaParameter>(DataHelper.GetFormulaParameters(f.Id, DataHelper.OpenOrCreateDb()));
                tbFormulaExp.TextChanged -= OnTextChanged;
                tbFormulaExp.Text = f.Expression;
                tbFormulaExp.TextChanged += OnTextChanged;
                gridRateParams.DataSource = formParameters;
                gridRateParams.Refresh();
            }
        } 


        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            foreach (var i in modifiedObjects)
            {
                var f = (Formula)viewRateList.GetRow(i.Key);
                int id = 0;
                if (i.Value == 1) {
                    if (f.Id == 0) {
                        continue;
                    }
                    DataHelper.RemoveFormula(f);
                }
                else {
                    id = DataHelper.SaveFormula(f);
                    foreach (var p in modifiedParams)
                    {
                        if (p.Value == 1)
                        {
                            DataHelper.RemoveFormulaParameter(((FormulaParameter)viewRateParams.GetRow(p.Key)).Id);
                        }
                        else
                        {

                            DataHelper.SaveFormulaParameter((FormulaParameter)viewRateParams.GetRow(p.Key), id);
                        }
                    }                    
                }
            }
            modifiedObjects.Clear();
            modifiedParams.Clear();
            gridRateList.RefreshDataSource();
            gridRateParams.RefreshDataSource();
        }

        private void OnParamCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) {
                if (!modifiedParams.ContainsKey(viewRateParams.DataRowCount))
                {
                    modifiedParams.Add(viewRateParams.DataRowCount, 2);
                    if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle))
                    {
                        modifiedObjects[viewRateList.FocusedRowHandle] = 2;
                    }
                    else
                    {
                        modifiedObjects.Add(viewRateList.FocusedRowHandle, 2);
                    }
                }
                return; 
            }
            if (viewRateParams.FocusedRowModified)
            {
                var f = (FormulaParameter)viewRateParams.GetRow(e.RowHandle);
                var i = f.Id == 0 ? 2 : 3;
                if (modifiedParams.ContainsKey(viewRateParams.FocusedRowHandle))
                {
                    modifiedParams[viewRateParams.FocusedRowHandle] = i;
                }
                else {
                    modifiedParams.Add(viewRateParams.FocusedRowHandle, i);
                }
                if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle))
                {
                    modifiedObjects[viewRateList.FocusedRowHandle] = 3;
                }
                else
                {
                    modifiedObjects.Add(viewRateList.FocusedRowHandle, 3);
                }
            }
        }

        private void OnCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                if (!modifiedObjects.ContainsKey(viewRateList.DataRowCount))
                {
                    modifiedObjects.Add(viewRateList.DataRowCount, 2);
                }
                return;
            }
            if (viewRateList.FocusedRowModified)
            {
                var f = (Formula)viewRateList.GetRow(e.RowHandle);
                var i = f.Id == 0 ? 2 : 3;
                if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle)) {
                    modifiedObjects[viewRateList.FocusedRowHandle] = i;
                }
                else {
                    modifiedObjects.Add(viewRateList.FocusedRowHandle, i);
                }
            }
        }
        
        private void OnCustomDrawCell(bool isParams, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = Color.LemonChiffon;
            int status = 0;
            if (isParams)
            {
                if (!modifiedParams.ContainsKey(e.RowHandle)) { return; }
                status = modifiedParams[e.RowHandle];
            }
            else
            {
                if (!modifiedObjects.ContainsKey(e.RowHandle)) { return; }
                status = modifiedObjects[e.RowHandle];
            }

            switch (status) {
                case 1: //Remove
                    {
                        e.Appearance.BackColor = Color.Gainsboro;
                        break;
                    }
                case 2: // New
                    {
                        e.Appearance.BackColor = Color.FromArgb(0x99, 0xFF, 0xFF);
                        break;
                    }
                case 3: // Edited
                    {
                        e.Appearance.BackColor = Color.FromArgb(253, 223, 239);
                        break;
                    }
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle))
            {
                modifiedObjects[viewRateList.FocusedRowHandle] = 3;
            }
            else
            {
                modifiedObjects.Add(viewRateList.FocusedRowHandle, 3);
            }
            ((Formula)viewRateList.GetFocusedRow()).Expression = tbFormulaExp.Text;
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            if (modifiedObjects.Count > 0 && DialogResult.Yes != MessageBox.Show("Вы действительно хотите закрыть форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose();
        }

        private void gridRateList_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.Remove:
                    {
                        if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle))
                        {
                            modifiedObjects[viewRateList.FocusedRowHandle] = 1;
                        }
                        else
                        {
                            modifiedObjects.Add(viewRateList.FocusedRowHandle, 1);
                        }
                        e.Handled = true;
                        return;
                    }
                case NavigatorButtonType.EndEdit:
                    {
                        var f = (Formula)viewRateList.GetFocusedRow();
                        var i = f.Id == 0 ? 2 : 3;

                        if (modifiedObjects.ContainsKey(viewRateList.FocusedRowHandle))
                        {
                            modifiedObjects[viewRateList.FocusedRowHandle] = i;
                        }
                        else
                        {
                            modifiedObjects.Add(viewRateList.FocusedRowHandle, i);
                        }
                        return;
                    }
                case NavigatorButtonType.Append:
                    {
                        var f = (Formula)viewRateList.GetFocusedRow();
                        if (modifiedParams.Count > 0)
                        {
                            foreach (var p in modifiedParams)
                            {
                                if (p.Value == 1)
                                {
                                    DataHelper.RemoveFormulaParameter(((FormulaParameter)viewRateParams.GetRow(p.Key)).Id);
                                }
                                else
                                {
                                    DataHelper.SaveFormulaParameter((FormulaParameter)viewRateParams.GetRow(p.Key), f.Id);
                                }
                            }                    
                        }
                        modifiedParams.Clear();
                        tbFormulaExp.TextChanged -= OnTextChanged;
                        tbFormulaExp.Text = string.Empty;
                        tbFormulaExp.TextChanged += OnTextChanged;
                        formParameters = new BindingList<FormulaParameter>();
                        gridRateParams.DataSource = formParameters;
                        gridRateParams.Refresh();
                        return;
                    }
            }
        }
    }
}
