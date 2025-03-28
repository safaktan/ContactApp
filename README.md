Conntact App

Bir microservice projesidir. ContactService ve ReportService içermektedir.
Migrationlar her servicesin kendi altında Migration klasörü altında bulunmaktadır.
Her servisin kendi alltında bulunan appsettings.json altında bulunan defaultConnection değerini kendi connection string değeriniz ile güncelleyiniz

ContactServive 5011, ReportService 5012 portunda çalışmaktadır.
Serviceler birbiri ile RabbitMq ile haberleşmektedir.
Sistem ReportService aracılığı ile kullanıcıya rapor sunmaktadır. Asekron çalışan rapor oluşturma işlemi RabbitMq üzerinden haberleşmektedir.

RabbitMq Docker kurulumu
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
RabbitMq
Adres: http://localhost:15672/
Kullanıcı Adı: guest
Parola: guest