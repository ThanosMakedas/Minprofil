namespace minprofil.Data;

using System.Collections.Concurrent;
using System.Security.Cryptography;

// Håller reda på inloggade sessioner i minnet. En token i användarens cookie
// pekar ut vilken användare sessionen tillhör. En session som inte används
// inom IdleTimeout slutar gälla.
public class SessionStore
{
    // Sessionscookiens livslängd utgår från den här tiden.
    public static readonly TimeSpan IdleTimeout = TimeSpan.FromMinutes(30);

    private readonly ConcurrentDictionary<string, Session> _sessions = new();

    public string Create(int userId)
    {
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        _sessions[token] = new Session(userId, DateTimeOffset.UtcNow.Add(IdleTimeout));
        return token;
    }

    public int? GetUserId(string? token)
    {
        if (string.IsNullOrEmpty(token) || !_sessions.TryGetValue(token, out var session))
        {
            return null;
        }

        if (session.ExpiresAt <= DateTimeOffset.UtcNow)
        {
            Invalidate(token);
            return null;
        }

        // Varje användning skjuter fram förfallotiden. TryUpdate gör inget om
        // sessionen hunnit tas bort under tiden, så en utloggad session kan
        // inte återuppstå här.
        _sessions.TryUpdate(token, session with { ExpiresAt = DateTimeOffset.UtcNow.Add(IdleTimeout) }, session);
        return session.UserId;
    }

    public void Invalidate(string? token)
    {
        if (!string.IsNullOrEmpty(token))
        {
            _sessions.TryRemove(token, out _);
        }
    }

    private record Session(int UserId, DateTimeOffset ExpiresAt);
}
