using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static newleme gerektirmez
    {
        public static string NameInvalid = " Geçersiz isim";
        public static string MaintenanceTime = " Sistem bakımda...";
        public static string DeletedOperation = " Silme işlemi başarılı";
        public static string UpdatedOperation = " Güncelleme işlemi başarılı";
        public static string AddedOperation = " Ekleme işlemi başarılı";
        public static string ListOperation = " Listeleme işlemi başarılı";
        public static string RentalInvalid = " Araç kullanıcıdadır, henüz teslim edilmemiştir";
        public static string ImageCountOfCarError = "Her aracın en fazla 5 fotoğrafı olabilir";
        public static string CarImagesCarIdNotEmpty = "Eklenmek istenen aracın CarId kısmı boş olamaz";
    }
}
