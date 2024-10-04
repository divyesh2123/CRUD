using ConsoleApp2;
using System.Text;

SmsInfoContext smsInfoContext = new SmsInfoContext();

var data = smsInfoContext.StudentInformations.ToList();




var emailTemplate = smsInfoContext.
    EmailTemplates.Where(y => y.EmailTemplateName == "Registration").FirstOrDefault();

foreach (var d in data)
{
    Dictionary<string, string> emailtag = new Dictionary<string, string>();
    emailtag.Add("##Name##", d.Name);
    emailtag.Add("##Email##", d.Email);
    emailtag.Add("##PhoneNumber##", d.PhoneNumber);
    var subj = new StringBuilder(emailTemplate.EmailSubject);
    var msg = new StringBuilder(emailTemplate.EmailBody);
    foreach (var t in emailtag)
    {
        msg.Replace(t.Key, t.Value);
        subj.Replace(t.Key, t.Value);
    }

    Helper.SendNotification(d.Email, subj.ToString(), msg.ToString());

}



