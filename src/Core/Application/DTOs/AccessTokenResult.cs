﻿namespace Application.DTOs
{
    public class AccessTokenResult
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
