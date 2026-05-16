using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using br.dev.avn.mangos.Application.Repositories;
using br.dev.avn.mangos.Domain.Entities;

namespace br.dev.avn.mangos.Infrastructure.Persistence.DynamoDB.Repositories;

public class DynamoLedgerRepository : ILedgerRepository
{
    private const string TableName = "ledger";
    private readonly IAmazonDynamoDB _client;

    public DynamoLedgerRepository(IAmazonDynamoDB client)
    {
        _client = client;
    }

    public async Task CreateCardTransaction(CreditCardTransaction transaction)
    {
        var item = new Dictionary<string, AttributeValue>
            {
                ["PK"] = new AttributeValue
                {
                    S = $"USER#{transaction.UserId}"
                },

                ["SK"] = new AttributeValue
                {
                    S =
                        $"TX#{transaction.CreatedAt:O}#{transaction.TransactionId}"
                },

                ["TransactionId"] =
                    new AttributeValue
                    {
                        S = transaction.TransactionId
                    },

                ["UserId"] =
                    new AttributeValue
                    {
                        S = transaction.UserId
                    },

                ["Value"] =
                    new AttributeValue
                    {
                        N = transaction.Value.ToString(
                            System.Globalization.CultureInfo.InvariantCulture)
                    },

                ["CreatedAt"] =
                    new AttributeValue
                    {
                        S = transaction.CreatedAt.ToString("O")
                    },

                ["Type"] =
                    new AttributeValue
                    {
                        S = "CREDIT_CARD_TRANSACTION"
                    }
            };

        var request = new PutItemRequest
        {
            TableName = TableName,
            Item = item,

            // Prevent overwrite
            ConditionExpression =
                "attribute_not_exists(PK) AND attribute_not_exists(SK)"
        };

        await _client.PutItemAsync(request);
    }
}