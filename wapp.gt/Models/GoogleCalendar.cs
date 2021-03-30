using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
namespace Wapp.gt.Models
{
    public class GoogleCalendar{
        public static string[] Scopes = { CalendarService.Scope.Calendar };
        public static string ApplicationName = "CalendarConsole";

        private string CredentialsPath = string.Empty;

        public GoogleCalendar(string credentialsPath)
        {
            CredentialsPath = credentialsPath;
        }

        public List<MisEventos> VerEventos()
        {
            List<MisEventos> eventos = new List<MisEventos>();
            UserCredential credential = GetCredential(UserRole.User);

            // Creat Google Calendar API service.
            CalendarService service = GetService(credential);

            // Define parameters of request
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            // Print upcomming events
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string inicio = eventItem.Start.DateTime.ToString();
                    string fin = eventItem.End.DateTime.ToString();

                    if (String.IsNullOrEmpty(inicio))
                    {
                        inicio = eventItem.Start.Date;
                        fin = eventItem.End.Date;
                    }
                    MisEventos ev = new MisEventos(eventItem.Summary, inicio, Convert.ToDateTime(fin));
                    eventos.Add(ev);
                }
            }
            else
            {
                Console.WriteLine("Nothing.");
            }
            return eventos;
        }

        public void CrearEvento(DateTime FI, DateTime FFIN,string Tema,string EmailT)
        {
            UserCredential credential = GetCredential(UserRole.Admin);
            CalendarService service = GetService(credential);

            Event newEvent = new Event()
            {
                Summary = Tema,
                Start = new EventDateTime() { DateTime = FI },
                End = new EventDateTime() { DateTime = FFIN },
                Attendees = new EventAttendee[] {
                        new EventAttendee() { Email = EmailT },
                        //new EventAttendee() { Email = "r.reategui@unas.edu.pe" },
                },
            };

            string calendarId = "primary";

            var recurringEvent = service.Events.Insert(newEvent, calendarId);
            recurringEvent.SendNotifications = true;
            recurringEvent.Execute();
            Console.WriteLine($"{newEvent.HtmlLink}");
        }

        private CalendarService GetService(UserCredential credential)
        {
            // Creat Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        private UserCredential GetCredential(UserRole userRole)
        {
            UserCredential credential;
            using (var stream =
                new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                userRole.ToString(),
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;

                Console.WriteLine($"Credential file saved to: {credPath}");
            }

            return credential;
        }
    }
}

