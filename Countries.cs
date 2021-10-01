using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrPochtaParser
{
    class Countries
    {
        public List<Country> List { get; } = new List<Country>();
        public List<string> ListBoxContent { get; } = new List<string>();

        public void ParseSourceStringToList(string sourceString)
        {
            char tab = '\u0009';
            string source = sourceString.Replace(tab.ToString(), ""); //удаляем Tab'ы из входящей строки

            String[] tariffs = source.Split('\n'); //разбиваем строку на массив строк

            List<string> tempList = new List<string>();

            foreach (var item in tariffs) //проверяем содержимое строк, меняем ',' на '.' и добавляем в список
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    //var _item = item.Replace(',', '.');
                    tempList.Add(item);
                }
            }

            for (int i = 0; i < tempList.Count; i += 8) //заполняем this.List объектами типа Country
            {
                this.List.Add(new Country(tempList[i]));
                this.ListBoxContent.Add(List[List.Count - 1].Name);

                int j = 0;

                for (; j < 6; j++)
                {
                    List[List.Count - 1].Tariffs.Add(tempList[(i + 2) + j]);
                }
            }
        }
    }
}