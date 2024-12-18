﻿using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public class DashboardService:IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DashboardData> GetDashboardDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<DashboardData>("https://localhost:7084/api/Dashboard");
            if(response == null)
            {
                throw new Exception("Failed to get dashboard data");
            }

            return response;

        }
    }
}
