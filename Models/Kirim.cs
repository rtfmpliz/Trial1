namespace trial1.Models
{
    public class Kirim
    {
        public int KirimID { get; set; }
        public int TruckID { get; set; }
        public string KaryawanNIK { get; set; }

        public Karyawan Karyawan { get; set; }
        public Truck Truck { get; set; }
    }
}