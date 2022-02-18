namespace Computing
{
    internal class Salary
    {
        /// <summary>
        /// Посчитать зарплату по количеству объектов и ставке
        /// </summary>
        /// <param name="countObject"> кол-во объектов </param>
        /// <param name="betForObject"> ставка </param>
        /// <returns></returns>
        public static int ComputeSalary(int countObject, int betForObject)
        {
            return countObject * betForObject;
        }
    }
}