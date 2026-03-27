
namespace MonitoreoDrones.Utilidades
{
    public static class UtilidadesGeograficas
    {
        public static double CalcularDistancia(double lat1, double long1, double lat2, double long2)
        {
            double R = 6371;
            double dLat = ConvertirRadianaes(lat2-lat1);
            double dLong = ConvertirRadianaes(long2 - long1);

            double a =
                Math.Sin(dLat/2)*Math.Sin(dLat/2)+
                Math.Cos(ConvertirRadianaes(lat1))*Math.Cos(ConvertirRadianaes(lat2))*
                Math.Sin(dLong/2)*Math.Sin(dLong/2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        public static double ConvertirRadianaes(double angulo)
        {
            return angulo = angulo*Math.PI / 180;
        }
    }
}
