using ApiTODO.Models;

namespace ApiTODO.Models;

public static class TodoService
{
    static List<TODO> Exercises { get; }
    static int nextId = 3;
    static TodoService()
    {
        Exercises = new List<TODO>
        {
            new TODO {nextId = 1, Exercise = "squad", Done = false},
            new TODO {nextId = 2, Exercise = "dip", Done = true}

        };

        public static List<TODO> GetAll() => Exercises;

        public static TODO? Get(int id) => Exercises.FirstOrDefault(p => p.Id == id);

        public static void Add(Exercises exercises)
        {
            exercises.Id = nextId++;
            Exercises.Add(exercises);
        }

        public static void Delete(int id)
        {
            var exercises = Get(id);
            if(exercises is null)
                return; 
            Exercises.Remove(exercises);   
        }

        public static void Update(Exercises exercises)
        {
            var index = Exercises.Findindex(p => p.Id == exercises.Id);
            if (index == -1)
                return;
            Exercises[index] = exercises;
        }
    }
}