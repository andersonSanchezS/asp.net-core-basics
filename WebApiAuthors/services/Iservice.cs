namespace WebApiAuthors.services
{
    public interface Iservice
    {
        void doTask();
    }


    public class serviceA : Iservice
    {
        public void doTask()
        {
            throw new NotImplementedException();
        }
    }

    public class serviceB : Iservice
    {
        public void doTask()
        {
            throw new NotImplementedException();
        }
    }
}
