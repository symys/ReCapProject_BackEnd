using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token oluşturuldu";
    }
}
