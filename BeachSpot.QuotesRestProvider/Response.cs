namespace BeachSpot.QuotesRestProvider;
internal class Response
{
    public Contents Contents { get; set; }
}

internal class Contents
{
    public QuoteObj[] Quotes { get; set; }
}

internal class QuoteObj
{
    public string Quote { get; set; }
}


