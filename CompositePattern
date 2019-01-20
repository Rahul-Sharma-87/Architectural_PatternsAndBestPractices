using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    interface IParty {
        int MoneyShare{ get; set; }

        void Stats();
    }

    class Person:IParty {
        public string Name { get; set; }
        public int MoneyShare { get; set; }

        public void Stats() {
            Console.WriteLine("Name : "+ Name +" MoneyShare : " + MoneyShare);
        }
    }

    class Group:IParty
    {
        public string Name { get; set; }

        public List<IParty> Persons{ get; set; }

        public int MoneyShare {
            get {
                int value =0 ;
                foreach (var person in Persons) {
                    value += person.MoneyShare;
                }
                return value;
            }
            set{
                int share = value / Persons.Count;
                foreach (var person in Persons) {
                    person.MoneyShare = share; 
                }
            }
        }

        public void Stats() {
            foreach (var person in Persons) {
                person.Stats();
            }
        }
    }

    class CompositePatternUsage
    {
        private static Person person1 = new Person() {Name = "Dev1", MoneyShare = 1000};
        private static Person person2 = new Person() {Name = "Dev2", MoneyShare = 2000};
        private static Person person3 = new Person() {Name = "Dev3", MoneyShare = 3000};
        private static Person person4 = new Person() {Name = "Dev4", MoneyShare = 4000};

        private static Person person5 = new Person() {Name = "Admin1", MoneyShare = 1000};
        private static Person person6 = new Person() {Name = "Admin2", MoneyShare = 2000};

        private static Person person7 = new Person() {Name = "IT1"};
        private static Person person8 = new Person() {Name = "IT2"};

        public static void GetShareAndDisplay()
        {
            //distribution
            Group group1 = new Group() {Name = "IT", Persons = new List<IParty>() {person7, person8}};
            group1.MoneyShare = 2000;
            group1.Stats();
            
            //Aggegated Get
            Group group2 = new Group() {Name = "Admin", Persons = new List<IParty>() {person5, person6}};
            group2.Stats();

            //Full Distribution
            Console.WriteLine("***********Full Distribution****************");

            List<IParty> parties = new List<IParty>() { group1, group2, person1, person2, person3, person4};

            var totalMoneyToShare = 8000;

            var perShare = totalMoneyToShare / parties.Count;

            foreach (var party in parties) {
                party.MoneyShare = perShare;
                party.Stats();
            }

            //Making one root- Proper tree stucture where it contains the group node and also individual nodes
            Console.WriteLine("***********Making one root****************");
            Group groupRoot = new Group() {Name = "RootGroup", Persons = parties};
            groupRoot.MoneyShare = totalMoneyToShare;
            groupRoot.Stats();
        }

    }
}
