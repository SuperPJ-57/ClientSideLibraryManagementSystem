﻿using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IDashboardService
    {
        Task<DashboardData> GetDashboardDataAsync();
    }
}
