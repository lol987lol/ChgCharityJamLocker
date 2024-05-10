﻿using LockerOpener.Configuration;
using LockerOpener.Models;

namespace LockerOpener.Services
{
    public class LockerClient
    {
        private readonly HttpClient _httpClient;
        private readonly LockerOptions _lockerOptions;

        public LockerClient(HttpClient httpClient, LockerOptions lockerOptions)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _lockerOptions = lockerOptions;
        }

        public async Task OpenLocker(string lockerId)
        {
            // get all lockers
            //var client = _httpClient.GetFromJsonAsync<LockerWall>($"/api/SmartHubUsers/lockerwalls/{_lockerOptions.SiteId}");

            var authResult = await _httpClient.PostAsJsonAsync("/api/account/Login", new
            {
                email = _lockerOptions.Authentication.Email,
                password = _lockerOptions.Authentication.Password,
                platform = _lockerOptions.Authentication.Platform,
            });

            authResult.EnsureSuccessStatusCode();

            var tokenResult = await authResult.Content.ReadFromJsonAsync<LockerAuthenticationResult>();

            _httpClient.DefaultRequestHeaders.Add("X-api-key", tokenResult.Result.AccessToken);

            var result = await _httpClient.PostAsJsonAsync("/api/SmartHubUsers/OpenLocker ", new
            {
                lockerId = lockerId,
                lockerOpenType = 1,
                userPin = _lockerOptions.GeneralPin
            });

            result.EnsureSuccessStatusCode();

            var lockerResult = await result.Content.ReadFromJsonAsync<GeneralLockerResult>();

            await Task.Yield();
        }
    }
}
