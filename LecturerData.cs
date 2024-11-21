using System.Collections.ObjectModel;

namespace CMCS4
{
    public static class LecturerData
    {
        public static ObservableCollection<Lecturer> Lecturers { get; set; } = new ObservableCollection<Lecturer>();
    }

    public class Lecturer
    {
        public string Name { get; set; }
        public string Contact { get; set; }
    }
}
