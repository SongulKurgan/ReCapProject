using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string CarUpdated = "Araba başarıyla güncellendi";
        public static string FailedCarAddOrUpdate = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz.";


        public static string BrandAdded = "Arabanın markası başarıyla eklendi";
        public static string BrandDeleted = "Arabanın Markası başarıyla silindi";
        public static string BrandUpdated = "Arabanın markası başarıyla güncellendi";
        public static string FailedBrandAddOrUpdate = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz.";


        public static string ColorAdded = "Arabanın rengi başarıyla eklendi";
        public static string ColorDeleted = "Arabanın rengi başarıyla silindi";
        public static string ColorUpdated = "Arabanın rengi başarıyla güncellendi";


        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi";


        public static string UserAdded = "Kullanıcı başarıyla eklendi";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi";


        public static string RentalAdded = "Araba kiralama işlemi başarıyla eklendi";
        public static string RentalDeleted = "Araba kiralama işlemi başarıyla silindi";
        public static string RentalUpdated = "Araba kiralama işlemi başarıyla güncellendi";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";


        public static string AddedCarImage = "Araba için yüklenilen resim başarıyla eklendi.";
        public static string DeletedCarImage = "Arabanın resmi başarıyla silindi.";
        public static string UpdatedCarImage = "Araba için yüklenilen resim başarıyla güncellendi.";
        public static string FailedCarImageAdd = "Bir araba 5'den fazla resme sahip olamaz.";

        public static string AuthorizationDenied="Yetkiniz yok";


        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        internal static string DeletedColor;
    }
}
