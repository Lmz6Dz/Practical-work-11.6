namespace Practical_work_11._6
{
    internal class Client
    {
        public uint iD;
        //Фамилия
        public string lastName;
        //Имя   
        public string firstName;
        //Отчество
        public string middleName;
        //Номер телефона
        public string phoneNumber;
        //Серия, номер паспорта
        public string passportNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LastName">Фамилия</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="PassportNumber">Серия, номер паспорта</param>
        public Client(uint ID, string LastName, string FirstName, string MiddleName,
                       string PhoneNumber, string PassportNumber)
        {
            this.iD = ID;
            lastName = LastName;
            firstName = FirstName;
            middleName = MiddleName;
            phoneNumber = PhoneNumber;
            passportNumber = PassportNumber;
        }

        public Client() : this(0, "", "", "", "", "")
        {

        }

        public override string ToString()
        {
            return $"{this.iD,3} {this.lastName,13} {this.firstName,14} {this.middleName,17} {this.phoneNumber,16} {passportNumber,23}";
        }
    }
}