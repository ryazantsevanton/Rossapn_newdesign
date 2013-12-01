using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class ChangeEventChecker : EventChecker
    {

        public string Name
        {
            get
            {
                return "Скачок параметра";
            }
        }

        public string Help
        {
            get
            {
                return "В качестве аргумента укажите значение значение интервала достоверности";
            }
        }

        public List<object[]> findEvents(List<object[]> metrix, string[] arguments)
        {
            throw new NotImplementedException();
        }

    }
}
