using System;
namespace ConsoleApp
{

    public class Program 
    {
        private const string NOMESSAGE = ""; 
        public static UnitOfWorkImpl unitOfWork = new UnitOfWorkImpl(); 
        public static void Main(string[] args) 
        {
            Menu(NOMESSAGE); 
        }

        public static void Menu(string returningMessage) 
        {
            Console.Clear(); 
            Console.WriteLine(" __  __         ____                                      ");
            Console.WriteLine("|  \\/  |_   _  |  _ \\ _ __ ___   __ _ _ __ __ _ _ __ ___  ");
            Console.WriteLine("| |\\/| | | | | | |_) | '__/ _ \\ / _` | '__/ _` | '_ ` _ \\ ");
            Console.WriteLine("| |  | | |_| | |  __/| | | (_) | (_| | | | (_| | | | | | |");
            Console.WriteLine("|_|  |_|\\__, | |_|   |_|  \\___/ \\__, |_|  \\__,_|_| |_| |_|");
            Console.WriteLine("        |___/                   |___/                     ");
            Console.WriteLine(" (v 0.0.1)   (com mais firulas do que nunca!)");

            Console.WriteLine("\n" + returningMessage + "\n"); 

            
            Console.WriteLine("1 - tenho dinheiro pra sair?");
            Console.WriteLine("2 - configurações do CRUD");
            Console.WriteLine("0 - sair do programa");

            Console.WriteLine("");

            char value = Console.ReadKey().KeyChar; 

            switch (value)
            { 
                case '1':
                    CheckValue(); 
                    break;
                case '2':
                    Configuration(NOMESSAGE); 
                    break;
                case '0':
                    System.Environment.Exit(0); 
                    break;
                default:
                    Menu("Por favor selecione uma opção valida!"); 
                    break;
            }
        }

        public static void CheckValue() 
        {
            float value = 0; 

            Console.WriteLine("\nQuanto dinheiro voçê tem?");

            string line = Console.ReadLine();

            if (float.TryParse(line, out value))
            {
                List<Place> places = unitOfWork.FindAll(); 

                if (places.Any()) 
                {

                    foreach (Place place in places)
                    {
                        if (place.Price <= value) 
                        {
                            Console.WriteLine("{ Nome: " + place.Name + " | Preço: " + place.Price + " }");
                        }
                    }

                    Console.WriteLine("Voçê consegue ir a esses lugares!");
                }
                else
                {
                    Console.WriteLine("Voçê não consegue ir pra lugar nenhum!");
                }
                Console.WriteLine("\n0 - voltar");
                Console.ReadKey();
                Menu(NOMESSAGE);
            }
        }

        public static void Configuration(string returningMessage) 
        {
            Console.Clear();
            Console.WriteLine("   ___ ___ _   _ ___  ");
            Console.WriteLine("  / __| _ \\ | | |   \\ ");
            Console.WriteLine(" | (__|   / |_| | |) |");
            Console.WriteLine("  \\___|_|_\\\\___/|___/ ");


            Console.WriteLine("\n" + returningMessage + "\n");

            Console.WriteLine("1 - ver todos os lugares para sair");
            Console.WriteLine("2 - salvar novo lugar para sair");
            Console.WriteLine("3 - atualizar lugar para sair");
            Console.WriteLine("4 - deletar lugar para sair");
            Console.WriteLine("0 - voltar");


            char value = Console.ReadKey().KeyChar;

            switch (value)
            {
                case '1':
                    SeeAll();
                    break;
                case '2':
                    Save();
                    break;
                case '3':
                    Update();
                    break;
                case '4':
                    Delete();
                    break;
                case '0':
                    Menu(NOMESSAGE);
                    break;
                default:
                    Configuration(NOMESSAGE);
                    break;
            }
        }

        public static void SeeAll() 
        {
            Console.Clear();
            unitOfWork.FindAll().ForEach(p => Console.WriteLine(p.toString()));
            Console.WriteLine("\n0 - voltar");
            Console.ReadKey();
            Configuration(NOMESSAGE);
        }

        public static void Save() 
        {
            Place place = new Place();

            Console.Clear();
            Console.WriteLine("Salvar Lugar");
            Console.WriteLine("Digite o nome do lugar/evento:");
            string line = Console.ReadLine();
            place.Name = line;
            line = null;

            Console.WriteLine("Digite o preço/valor do lugar/evento:");
            line = Console.ReadLine();
            if (float.TryParse(line, out float value))
            {
                place.Price = value;

                unitOfWork.Save(place);

                Configuration("salvo com sucesso!");
            }
            Configuration("Valores invalidos!");
        }

        public static void Update() 
        {
            Place place = new Place();

            Console.Clear();
            Console.WriteLine("Digite o novo nome do lugar/evento:");
            string line = Console.ReadLine();
            place.Name = line;
            line = null;

            Console.WriteLine("Digite o novo preço/valor do lugar/evento:");
            line = Console.ReadLine();
            if (float.TryParse(line, out float fvalue))
            {
                place.Price = fvalue;
            }
            line = null;

            unitOfWork.FindAll().ForEach(p => Console.WriteLine(p.toString()));
            Console.WriteLine("\nInforme o Id do lugar para atualizar:");
            line = Console.ReadLine();
            if (int.TryParse(line, out int ivalue))
            {
                place.Id = ivalue;
                unitOfWork.Update(ivalue, place);
                Configuration("atualizado com sucesso!");
            }
            Configuration("Valores invalidos!");
        }

        public static void Delete() 
        {
            Console.Clear();
            unitOfWork.FindAll().ForEach(p => Console.WriteLine(p.toString()));
            Console.WriteLine("\nInforme o Id do lugar para deletar:");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int ivalue))
            {
                unitOfWork.Delete(ivalue);
                Configuration("deletado com sucesso!");
            }
            Configuration("Valor invalido!");
        }
    }


    public class Place 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public string toString() 
        {
            return "{ id: " + Id + " Lugar: " + Name + ", Preço: " + Price + " }";
        }
    }

    public interface IUnitOfWork<T> 
    {

        List<T> FindAll();
        T FindById(int id);
        void Save(Place place);
        void Update(int id, Place place);
        void Delete(int id);
    }

    public class UnitOfWorkImpl : IUnitOfWork<Place> 
    {
        private List<Place> places = new List<Place>(); 

        public void Delete(int id)
        {
            places.Remove(FindById(id));
        }

        public List<Place> FindAll()
        {
            return places;
        }

        public Place FindById(int id)
        {
            foreach (Place place in places)
            {
                if (place.Id == id)
                {
                    return place;
                }
            }
            return null;
        }

        public void Save(Place place)
        {
            place.Id = IdGenerator.Instance.next();
            places.Add(place);
        }

        public void Update(int id, Place newPlace)
        {
            var place = FindById(id);
            places.Remove(place);
            place = newPlace;
            places.Add(place);

        }
    }

    public sealed class IdGenerator 
    {
        private static IdGenerator instance = null;
        private static readonly object locker = new object();
        private int id = 0;

        IdGenerator() { }

        public int next()
        {
            return id++;
        }

        public static IdGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new IdGenerator();
                        }

                    }
                }
                return instance;
            }
        }

    }

}
