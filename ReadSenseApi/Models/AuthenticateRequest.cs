﻿using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ReadSenseApi.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string? Username { get; set; }

        public string? Password { get; set; }

        /// <summary>
        /// User Device Information as a Json string 
        /// </summary>
        [JsonPropertyName("deviceInfo")]
        public JsonNode? DeviceInfo { get; set; }
    }
}
