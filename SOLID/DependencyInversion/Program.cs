// See https://aka.ms/new-console-template for more information
using DependencyInversion;

Console.WriteLine("Hello, World!");
/*
 * Dependency Inversion Principle der ki:
 * Büyük nesneler, küçük nesnelere bağlı olmamalıdır. Her ikisi de soyutlamalara bağlı olmalıdır.
 */

WhatsAppSender whatsAppSender = new WhatsAppSender();
MailSender mailSender = new MailSender();
TelegramSender telegramSender = new TelegramSender();

Report report = new Report(whatsAppSender);
report.SendReport();

report = new Report(mailSender);
report.SendReport();

report = new Report(telegramSender);
report.SendReport();


