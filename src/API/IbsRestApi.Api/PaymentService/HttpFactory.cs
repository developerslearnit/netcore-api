﻿using System.Net.Http.Headers;
using System.Net;

namespace IbsRestApi.Api.PaymentService;

public static class HttpFactory
{
    public static HttpClient InitHttpClient(string baseUrl)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        var client = new HttpClient()
        {
            BaseAddress = new Uri(baseUrl)
        };

        client.DefaultRequestHeaders.Clear();

        return client;
    }

    public static HttpClient AddMediaType(this HttpClient client, string mediaType)
    {
        client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue(mediaType));

        return client;
    }


    public static HttpClient AddHeader(this HttpClient client, string headerKey, string headerVal)
    {
        client.DefaultRequestHeaders.Add(headerKey, headerVal);

        return client;
    }


    public static HttpClient AddAuthorizationHeader(this HttpClient client, string authType, string secretKey)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType, secretKey);

        return client;
    }
}
