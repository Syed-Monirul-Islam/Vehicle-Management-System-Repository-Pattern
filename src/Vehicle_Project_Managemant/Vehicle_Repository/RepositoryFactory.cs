namespace Vehicle_Repository
{
    public static class RepositoryFactory
    {
         
        public static TRepository Create<TRepository>(ContextTypes contextType)
            where TRepository : class
        {
            if (contextType == ContextTypes.XMLSource)
            {
                 
                if (typeof(TRepository) == typeof(IVehicleRepository))
                {
                    return new VehicleXMLRepository() as TRepository;
                }
            }

            return null;
        }
    }
}
