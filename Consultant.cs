using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Practical_work_11._6
{
    internal class Consultant
    {
        private ObservableCollection<Client> Clients; // Основной массив для хранения данных
        private readonly string path; // Путь к файлу с данными

        public Consultant(string path)
        {
            this.Clients = new ObservableCollection<Client>();
            this.path = path;
            Load();
        }

        /// <summary>
        /// Загрузки данных
        /// </summary>
        public void Load()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        Clients.Add(new Client(Convert.ToUInt32(args[0]), args[1], args[2], args[3], args[4], args[5]));
                    }
                }
            }
        }

        /// <summary>
        /// Отображение информации
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.Clear();
            Console.WriteLine($"{"ID",3} {"Фамилия",13} {"Имя",14} {"Отчество",17} {"Номер телефона",16} {"Серия, номер паспорта",23}");

            foreach (var person in Clients)
            {
                if (person.passportNumber != string.Empty)
                {
                    person.passportNumber = "******************";
                }

                Console.WriteLine(person);
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Редактирование записи
        /// </summary>
        public void EditRecord()
        {
            Console.Clear();
            Console.Write("Введите ID записи для редактирования: ");
            uint id = Convert.ToUInt16(Console.ReadLine());
            char k;

            foreach (var person in Clients)
            {
                if (person.iD == id)
                {
                    Console.WriteLine(person.phoneNumber);
                    Console.WriteLine("Изменить Номер телефона н/д");
                    k = Console.ReadKey(true).KeyChar;
                    if (k == 'д')
                    {
                        do
                        {
                            Console.WriteLine("Новый Номер телефона: ");
                            person.phoneNumber = Console.ReadLine();
                        }
                        while (person.phoneNumber == string.Empty);
                    }
                }

            }

            Save();
        }

        /// <summary>
        /// Сохранения данных
        /// </summary>
        void Save()
        {
            string temp;
            File.Delete(path);

            foreach (var person in Clients)
            {
                temp = Path.Combine(path, person.lastName);

                temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}",
                                        person.iD,
                                        person.lastName,
                                        person.firstName,
                                        person.middleName,
                                        person.phoneNumber,
                                        person.passportNumber);

                File.AppendAllText(path, $"{temp}\n", Encoding.Unicode);
            }
        }

    }
}

