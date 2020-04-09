using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using FoodSafety.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FoodSafety.API.Data
{
    public class Seed
    {
//"&$select=business_id,name,phone,address,MAX(inspection_date),grade,city, zip_code, program_identifier,description,longitude,latitude,inspection_serial_num,violation_record_id,violation_type&$group=business_id,name,phone,address,city, zip_code, grade, program_identifier,description,longitude,latitude,inspection_serial_num,violation_record_id,violation_type");

        public static async void SeedRestuarants(DataContext context, IHttpClientFactory clientFactory, IMapper mapper)
        {

            if (!context.Restuarants.Any())
            {
                const string data = "https://data.kingcounty.gov/resource/f29f-zza5.json";

                var restaurantData = data;

                int n = 0;
                int offset = 0;
                int limit = 5;
                
                while (n < 40)
                {
                    //PR0067531
                    var request = new HttpRequestMessage(HttpMethod.Get, restaurantData + "?$limit="+ limit +"&$offset="+ offset);
                    var client = clientFactory.CreateClient();

                    var res = await client.SendAsync(request);

                    if (res.IsSuccessStatusCode)
                    {
                        var responseStream = await res.Content.ReadAsStreamAsync();
                        var list = DeserializeJsonFromStream<IEnumerable<RestuarantDeserializer>>(responseStream);

                        foreach (RestuarantDeserializer r in list)
                        {
                            var restaurant = context.Restuarants.Find(r.BusinessID);
                            if (restaurant == null) {
                                restaurant = mapper.Map<Restuarant>(r);
                                context.Add(restaurant);
                            }
                            
                            if (r.InspectionSerialNum != null)
                            {
                                var inspection = context.Inspections.Find(r.InspectionSerialNum);
                                if (inspection == null)
                                {
                                    inspection = mapper.Map<Inspection>(r);
                                    inspection.Restuarant = restaurant;
                                    context.Add(inspection);
                                    if(restaurant.Inspections == null)
                                        restaurant.Inspections = new List<Inspection>();
                                    restaurant.Inspections.Add(inspection);
                                    
                                }

                                if(r.ViolationRecordId != null)
                                {
                                    var violation = context.Violations.Find(r.ViolationRecordId);
                                    if (violation == null)
                                    {
                                        violation = mapper.Map<Violation>(r);;
                                        context.Add(violation);

                               

                                        if(inspection.Violations == null)
                                            inspection.Violations = new List<Violation>();

                                        inspection.Violations.Add(violation);
                                    }
                                } 
                            }

                        }

                        context.SaveChanges();
                    }
                    n ++;
                    offset = offset+ limit;
                }
                
            }

        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new Newtonsoft.Json.JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }
    }
}



// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Net.Http;
// using System.Threading.Tasks;
// using AutoMapper;
// using FoodSafety.API.Models;
// using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;

// namespace FoodSafety.API.Data
// {
//     public class Seed
//     {
// //"&$select=business_id,name,phone,address,MAX(inspection_date),grade,city, zip_code, program_identifier,description,longitude,latitude,inspection_serial_num,violation_record_id,violation_type&$group=business_id,name,phone,address,city, zip_code, grade, program_identifier,description,longitude,latitude,inspection_serial_num,violation_record_id,violation_type");
//         const string apiURL = "https://data.kingcounty.gov/resource/f29f-zza5.json";
        
//         public static async void SeedRestuarants(DataContext context, IHttpClientFactory clientFactory, IMapper mapper)
//         {

//             if (!context.Restuarants.Any())
//             {
                

//                 int n = (int) Math.Ceiling(25.0);
//                 int offset = 0;
//                 int limit = 5;


//                 var client = clientFactory.CreateClient();
//                 List<string> requestUrlList = SetUpURLList(n, offset, limit);
//                 // when executed, returns a collection of taksk
//                 IEnumerable<Task> requestTasksQuery = from url in requestUrlList select ProcessURL(url, client, context, mapper);
//                 List<Task> serializeTasks = requestTasksQuery.ToList();
//                 while (serializeTasks.Count > 0)
//                 {
//                     Task firstFinishedTask = await Task.WhenAny(serializeTasks);
//                     serializeTasks.Remove(firstFinishedTask);
                        
//                 }
                
//             }

//         }

//         private static List<string> SetUpURLList(int n, int offset, int limit)
//         {
//             List<string> urls = new List<string>();
            
//             while (offset < n)
//             {
//                 urls.Add(apiURL + "?$limit="+ limit +"&$offset="+ offset);
//                 offset = offset + limit;
                
//             }
//             return urls;
//         }

//         private static async Task ProcessURL(string url, HttpClient client, DataContext context, IMapper mapper)
//         {
//             var request = new HttpRequestMessage(HttpMethod.Get, url);

//             var res = await client.SendAsync(request);

//             if (res.IsSuccessStatusCode)
//             {
//                 var responseStream = await res.Content.ReadAsStreamAsync();
//                 var list = DeserializeJsonFromStream<IEnumerable<RestuarantDeserializer>>(responseStream);

//                 foreach (RestuarantDeserializer r in list)
//                 {
                            
//                     var restaurant = context.Restuarants.Find(r.BusinessID);
//                     if (restaurant == null) {
//                         restaurant = mapper.Map<Restuarant>(r);
//                         context.Add(restaurant);
//                     }
                            
//                     if (r.InspectionSerialNum != null)
//                     {
//                         var inspection = context.Inspections.Find(r.InspectionSerialNum);
//                         if (inspection == null)
//                         {
//                             inspection = mapper.Map<Inspection>(r);
//                             inspection.Restuarant = restaurant;
//                             context.Add(inspection);
//                             if(restaurant.Inspections == null)
//                                 restaurant.Inspections = new List<Inspection>();
//                             restaurant.Inspections.Add(inspection);
                                    
//                         }

//                         if(r.ViolationRecordId != null)
//                         {
//                             var violation = context.Violations.Find(r.ViolationRecordId);
//                             if (violation == null)
//                             {
//                                 violation = mapper.Map<Violation>(r);;
//                                 context.Add(violation);

                               

//                                 if(inspection.Violations == null)
//                                     inspection.Violations = new List<Violation>();
//                                 inspection.Violations.Add(violation);
//                             }
//                         } 
//                     }
//                 }

//                 context.SaveChanges();
//             }
                    
//         }

//         private static T DeserializeJsonFromStream<T>(Stream stream)
//         {
//             if (stream == null || stream.CanRead == false)
//                 return default(T);

//             using (var sr = new StreamReader(stream))
//             using (var jtr = new JsonTextReader(sr))
//             {
//                 var js = new Newtonsoft.Json.JsonSerializer();
//                 var searchResult = js.Deserialize<T>(jtr);
//                 return searchResult;
//             }
//         }
//     }
// }