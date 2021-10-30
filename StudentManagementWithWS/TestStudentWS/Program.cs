﻿using System;
using System.Net.Http;

namespace TestStudentWS
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                var responseTask = client.SendAsync("Student?keyword=test");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    Console.WriteLine(readTask.Result);
                }
            }
        }
    }
}