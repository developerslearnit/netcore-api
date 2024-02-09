namespace IbsRestApi.Communications.Model;
public class EmailViewModel
{
    // Receiver
    public string ToEMails { get; }
    public string CcEmails { get; }
    public string BccEmails { get; }
       

    // Content
    public string Subject { get; }
    public string Body { get; }

    //Attachment
    public string AttachmentPath { get; set; }

    public EmailViewModel(string toEmails, string subject, string body,string attachmentPath=null,
        string ccEmails=null,string bccEmails=null)
    {
        // Receiver
        ToEMails = toEmails;
        CcEmails = ccEmails;
        BccEmails = bccEmails;
        

        // Content
        Subject = subject;
        Body = body;
        AttachmentPath = attachmentPath;
    }
}
