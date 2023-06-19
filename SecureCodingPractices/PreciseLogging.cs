using System;
using NLog;

class PreciseLogging
{
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public static void Trigger()
    {
        TransferFunds("John", "Ron", 100.0);
    }

    public static void TransferFunds(string sender, string recipient, double amount)
    {
        // Perform the funds transfer
        // ...
    logger.Info("Action : {0},  Sender : {1},  amount = {2}, reciever : {3}", "Transfer", sender, amount, recipient);
    }
} 