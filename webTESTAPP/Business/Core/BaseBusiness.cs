using Data;

namespace webTESTAPP.Bussiness.Core
{
    public class BaseBusiness
    {
        protected readonly UnitOfWork uow;

        public BaseBusiness(UnitOfWork _uow)
        {
            uow = _uow;
        }
    }
}
