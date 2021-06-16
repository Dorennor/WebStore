namespace WebStore.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Device device = obj as Device;
            return (device.ID == ID && device.Name == Name && device.Type == Type && device.Manufacturer == Manufacturer && device.Price == Price);
        }
    }
}