namespace DataManager.Services;

public class DataService : IDataService
{
    private readonly RealEstate_AppContext _context;

    public DataService(RealEstate_AppContext context)
    {
        _context = context;
    }

    public async Task<Contract> CreateContract(Contract contract)
    {
        try
        {
            contract.ContractHtml = "<!DOCTYPE  html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"ro\" lang=\"ro\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><title>file_1655842102727</title><meta name=\"author\" content=\"Corina Varlan\"/><style type=\"text/css\"> * {margin:0; padding:0; text-indent:0; }\n h1 { color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: bold; text-decoration: none; font-size: 11pt; }\n .s1 { color: black; font-family:Arial, sans-serif; font-style: italic; font-weight: normal; text-decoration: none; font-size: 11pt; }\n .p, p { color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; margin:0pt; }\n .s2 { color: black; font-family:\"Times New Roman\", serif; font-style: normal; font-weight: normal; text-decoration: underline; font-size: 11pt; }\n .s3 { color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: underline; font-size: 11pt; }\n .s4 { color: black; font-style: normal; font-weight: normal; text-decoration: none; }\n li {display: block; }\n #l1 {padding-left: 0pt;counter-reset: c1 1; }\n #l1> li>*:first-child:before {counter-increment: c1; content: counter(c1, decimal)\". \"; color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; }\n #l1> li:first-child>*:first-child:before {counter-increment: c1 0;  }\n li {display: block; }\n #l2 {padding-left: 0pt;counter-reset: d1 1; }\n #l2> li>*:first-child:before {counter-increment: d1; content: counter(d1, decimal)\". \"; color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; }\n #l2> li:first-child>*:first-child:before {counter-increment: d1 0;  }\n #l3 {padding-left: 0pt; }\n #l3> li>*:first-child:before {content: \"- \"; color: black; font-family:Calibri, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; }\n #l4 {padding-left: 0pt; }\n #l4> li>*:first-child:before {content: \"- \"; color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; }\n li {display: block; }\n #l5 {padding-left: 0pt; }\n #l5> li>*:first-child:before {content: \"- \"; color: black; font-family:Arial, sans-serif; font-style: normal; font-weight: normal; text-decoration: none; font-size: 11pt; }\n</style></head><body><h1 style=\"padding-top: 4pt;padding-left: 164pt;text-indent: 0pt;text-align: center;\">CONTRACT DE ÎNCHIRIERE</h1><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p class=\"s1\" style=\"padding-left: 164pt;text-indent: 0pt;text-align: center;\">-model-</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-top: 4pt;padding-left: 5pt;text-indent: 0pt;text-align: left;\">Încheiat   astăzi   <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-top: 4pt;padding-left: 5pt;text-indent: 0pt;text-align: left;\">Între subsemnaţii:</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><ol id=\"l1\"><li data-list-text=\"1.\"><p class=\"s3\" style=\"padding-left: 41pt;text-indent: -18pt;text-align: left;\"> <span class=\"p\">domiciliat(ă) în</span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-left: 41pt;text-indent: 0pt;line-height: 1pt;text-align: left;\"/><p style=\"padding-top: 5pt;padding-left: 41pt;text-indent: 0pt;text-align: left;\">posesor a B.I/C.I. seria <u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </u>nr. <u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </u>eliberat de <u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </u></p><p class=\"s3\" style=\"padding-top: 6pt;padding-left: 41pt;text-indent: 0pt;line-height: 150%;text-align: left;\"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class=\"p\">la data de </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class=\"p\">în calitate de proprietar al imobilului situat la adresa</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p></li><li data-list-text=\"2.\"><p class=\"s3\" style=\"padding-left: 41pt;text-indent: -18pt;line-height: 150%;text-align: left;\"><span class=\"s4\">\t</span> <span class=\"p\">domiciliat(ă) în</span> <span class=\"p\"> posesor a B.I./C.I. seria</span> <span class=\"p\">nr. </span>&nbsp;<span class=\"p\">eliberat de </span>&nbsp;</p></li></ol><p class=\"s2\" style=\"padding-left: 41pt;text-indent: 0pt;text-align: left;\"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class=\"p\">la data de </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class=\"p\">în calitate de chiriaş.</span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: left;\">Primul în calitate de proprietar închiriez, iar al doilea în calitate de chiriaş iau în chirie imobilul situat la adresa <u>&nbsp;</u> compus din <u>&nbsp;&nbsp;&nbsp;&nbsp; </u>camere plus dependinţe, nemobilate / mobilate conform listei de inventar ce se va întocmi de către părţi la data intrării în imobil.</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><ol id=\"l2\"><li data-list-text=\"1.\"><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: justify;\">Termenul de închiriere este de la data de <span class=\"s2\">&nbsp;</span>până la data de <u>&nbsp;</u> cu posibilitate de prelungire prin acordul ambelor părţi.</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li><li data-list-text=\"2.\"><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: left;\">Chiria lunară este de <span class=\"s2\">&nbsp;</span>Plata se face în numerar/prin virament bancar, până la data de <u>&nbsp;</u>a lunii pentru luna în curs.</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li><li data-list-text=\"3.\"><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: justify;\">Părţile au convenit astfel: chiriaşul să plătească proprietarului suma de <span class=\"s2\">&nbsp;</span>cu titlul de garanţie pentru plata chiriei și a cheltuielilor ce cad în sarcina chiriaşului şi care privesc imobilul ce face obiectul prezentului contract. Proprietarul se obligă ca la încetarea raporturilor dintre părţi, raporturi ce rezultă sau sunt consecinţa prezentului contract de închiriere, să</p><p style=\"padding-top: 4pt;padding-left: 5pt;text-indent: 0pt;text-align: left;\">restituie chiriaşului această sumă de bani.</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li><li data-list-text=\"4.\"><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: left;\">În momentul încheierii contractului s-a plătit de către chiriaş suma de <u>&nbsp; </u> reprezentând <u>&nbsp;</u></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li><li data-list-text=\"5.\"><p style=\"padding-top: 4pt;padding-left: 17pt;text-indent: -12pt;text-align: left;\">Încetarea contractului se face :</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><ul id=\"l3\"><li data-list-text=\"-\"><p style=\"padding-left: 41pt;text-indent: -18pt;text-align: left;\">la împlinirea termenului prevăzut la art. 1,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 5pt;padding-left: 41pt;text-indent: -18pt;text-align: left;\">prin acordul ambelor părţi înainte de termen,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 5pt;padding-left: 41pt;text-indent: -18pt;text-align: left;\">prin denunțare unilaterală cu un preaviz de 30 zile calendaristice,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 5pt;padding-left: 41pt;text-indent: -18pt;line-height: 143%;text-align: left;\">prin reziliere în caz de nerespectare a clauzelor contractuale, fără alte formalități și fără trecerea vreunui termen.</p><p style=\"padding-top: 8pt;padding-left: 23pt;text-indent: 0pt;line-height: 151%;text-align: left;\">În situaţia în care oricare din părţi nu respectă aceste condiţii va plăti celeilalte părţi despăgubiri în valoare de <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li></ul></li><li data-list-text=\"6.\"><h1 style=\"padding-top: 4pt;padding-left: 35pt;text-indent: -12pt;text-align: left;\">OBLIGAŢIILE CHIRIAŞULUI:</h1><ul id=\"l4\"><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 23pt;text-indent: 0pt;line-height: 150%;text-align: left;\">chiriaşul se obligă să folosească bunul închiriat conform destinaţiei sale, să nu tulbure liniştea proprietăţilor vecine prin folosinţa sa,</p></li><li data-list-text=\"-\"><p style=\"padding-left: 29pt;text-indent: -6pt;text-align: left;\">va preda imobilul la finalul perioadei de locaţiune în condiţiile iniţiale preluării lui,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 29pt;text-indent: -6pt;text-align: left;\">nu va subînchiria imobilul,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 23pt;text-indent: 0pt;line-height: 150%;text-align: left;\">să plătească la termen/scadență cheltuielile de folosinţa a imobilului (apă, gaz, electricitate, etc),</p></li><li data-list-text=\"-\"><p style=\"padding-left: 23pt;text-indent: 0pt;line-height: 150%;text-align: left;\">să respecte normele de prevenire a incendiilor şi să întreţină bunurile în folosinţă exclusive (instalaţii de apă, gaz metan, mobilier),</p></li><li data-list-text=\"-\"><p style=\"padding-left: 29pt;text-indent: -6pt;line-height: 13pt;text-align: left;\">să păstreze curăţenia şi să respecte normele de igienă în interiorul imobilului,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 23pt;text-indent: 0pt;line-height: 150%;text-align: left;\">să restituie imobilul la data expirării contractului sau la încetarea acestuia înainte de termen în condiţiile prezentului contract,</p></li><li data-list-text=\"-\"><p style=\"padding-left: 23pt;text-indent: 0pt;line-height: 151%;text-align: left;\">să despăgubească proprietarul de eventualele daune produse imobilului sau bunurilor din interiorul acestuia din folosinţa sa,</p></li><li data-list-text=\"-\"><p style=\"padding-left: 29pt;text-indent: -6pt;line-height: 13pt;text-align: left;\">să nu schimbe destinaţia imobilului.</p></li></ul><p style=\"text-indent: 0pt;text-align: left;\"><br/></p></li><li data-list-text=\"7.\"><h1 style=\"padding-left: 35pt;text-indent: -12pt;text-align: left;\">OBLIGAŢIILE PROPRIETARULUI:</h1></li></ol><ul id=\"l5\"><li data-list-text=\"-\"><p style=\"padding-top: 4pt;padding-left: 29pt;text-indent: -6pt;text-align: left;\">proprietarul se obligă să predea imobilul la data stabilită în contract în stare de folosinţă,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 23pt;text-indent: 0pt;line-height: 150%;text-align: left;\">proprietarul se obligă să asigure locatorului imobilul potrivit destinaţiei pentru care a fost închiriat,</p></li><li data-list-text=\"-\"><p style=\"padding-left: 29pt;text-indent: -6pt;line-height: 13pt;text-align: left;\">garantează chiriaşului împotriva viciilor ascunse ale imobilului <u>&nbsp;</u>,</p></li><li data-list-text=\"-\"><p style=\"padding-top: 6pt;padding-left: 29pt;text-indent: -6pt;text-align: left;\">garantează pentru evicțiune.</p></li></ul><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-left: 5pt;text-indent: 0pt;text-align: left;\">Predarea imobilului către chiriaş se va face cel mai târziu la data de <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>.</p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 151%;text-align: left;\">Prezentul contract conţine trei pagini şi s-a încheiat în două exemplare, astăzi fiecare parte intrând în posesia unui exemplar din contract.</p><p style=\"padding-top: 7pt;padding-left: 5pt;text-indent: 0pt;line-height: 150%;text-align: left;\">La  preluarea  imobilului,  aparatele  de  măsură  aveau  următoarele  indexuri:  Index  contor  apă  caldă  <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"padding-left: 5pt;text-indent: 0pt;line-height: 13pt;text-align: left;\">Index   contor   apă  rece     <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"padding-top: 6pt;padding-left: 5pt;text-indent: 0pt;text-align: left;\">Index   energie   electrică      <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"padding-top: 10pt;padding-left: 5pt;text-indent: 0pt;text-align: left;\">La  data  închirierii  la  asociaţia  de  proprietari  era  de  plată  suma  de  <span class=\"s2\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><p style=\"text-indent: 0pt;text-align: left;\"><br/></p><h1 style=\"padding-left: 5pt;text-indent: 0pt;text-align: left;\">PROPRIETAR                                     CHIRIAŞ</h1></body></html>\n";
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            //var currentProperty = _context.Properties.Where(i => i.PropertyId == contract.PropertyId).FirstOrDefault();
            //var chat = new Chat
            //{
            //    TenantId = contract.TenantId,
            //    LandlordId = currentProperty.UserId,
            //    ChatLogs = null
            //};
            //_context.Chats.Add(chat);
            //await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {

        }

        return contract;
    }

    public async Task<Chat> CreateChat(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<Property> CreateProperty(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }


    public async Task<User> CreateUserAccount(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Contract> DeleteContract(int contractId)
    {
        var contractToDelete = _context.Contracts.Where(x => x.ContractId == contractId).FirstOrDefault();
        if (contractToDelete is null)
            return null;
        _context.Contracts.Remove(contractToDelete);
        await _context.SaveChangesAsync();
        return contractToDelete;
    }


    public async Task<Property> DeleteProperty(int propertyId)
    {
        var propertyToDelete = _context.Properties.Where(x=> x.PropertyId == propertyId).FirstOrDefault();
        if (propertyToDelete is null)
            return null;
        _context.Properties.Remove(propertyToDelete);
        await _context.SaveChangesAsync();
        return propertyToDelete;
    }


    public async Task<User> DeleteUserAccount(int userId)
    {
        var userToDelete = _context.Users.Where(x => x.UserId == userId).FirstOrDefault();
        if (userToDelete is null)
            return null;
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return userToDelete;
    }

    public async Task<List<Contract>> GetContracts()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<List<Role>> GetCurrentRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public List<Property> GetProperties()
    {
        var items = _context.Properties.AsQueryable();
        items = items.Include(i => i.User);
        items = items.Include(i => i.Contract);
        items = items.Include(i => i.UploadedImages).Where(i => i.Unlisted == false);
        var res = (from property in items
                   select new Property
                   {
                       PropertyId = property.PropertyId,
                       PropertyName = property.PropertyName,
                       Address = property.Address,
                       City = property.City,
                       UserId = property.UserId,
                       Value = property.Value,
                       User = new User
                       {
                           Address = property.User.Address,
                           UserId = property.User.UserId,
                           Email = property.User.Email,
                           FirstName = property.User.FirstName,
                           LastName = property.User.LastName,
                           PhoneNumber = property.User.PhoneNumber
                       },
                       UploadedImages = (ICollection<UploadedImage>)
                                        (from image in property.UploadedImages
                                         select new UploadedImage
                                         {
                                             ImageData = image.ImageData,
                                             ImageId = image.ImageId
                                         }),
                       Contract = new Contract
                       {
                           TenantId = property.Contract.TenantId,
                       }
                   }).ToList();
        return res;
    }


    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmail(string email) => await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

    public async Task<Contract> UpdateContract(Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }


    public async Task<Property> UpdateProperty(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<User> UpdateUserAccount(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _context.Users.Where(i => i.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<UploadedImage> TransferImageToDatabase(UploadedImage uploadedImage)
    {
        _context.UploadedImages.Add(uploadedImage);
        await _context.SaveChangesAsync();
        return uploadedImage;
    }

    public async Task<Property> GetPropertyById(int propertyId)
    {
        return await _context.Properties.Where(i => i.PropertyId == propertyId).FirstOrDefaultAsync();
    }

    public async Task<List<UploadedImage>> GetUploadedImagesByPropertyId(int propertyId)
    {
        return await _context.UploadedImages.Where(i => i.PropertyId == propertyId).ToListAsync();
    }

    public async Task<List<Contract>> GetContractsByLandlordId(int landlordId)
    {
        var items = _context.Contracts.Include(i => i.Property).Where(i => i.Property.UserId == landlordId);
        items = items.Include(i => i.Tenant);
        var res = await (from contract in items
                   select new Contract
                   {
                       ContractId = contract.ContractId,
                       PropertyId = contract.PropertyId,
                       TenantId = contract.TenantId,
                       Signed = contract.Signed,
                       Tenant = new User
                       {
                           FirstName = contract.Tenant.FirstName,
                           LastName = contract.Tenant.LastName,
                           PhoneNumber = contract.Tenant.PhoneNumber,
                       },
                       Property = new Property
                       {
                           Address = contract.Property.Address,
                       }
                   }).ToListAsync();
        return res;
    }

    public async Task<List<Contract>> GetContractsByTenantId(int tenantId)
    {
        var items = _context.Contracts.Include(i => i.Property).ThenInclude(i => i.User).Where(i => i.TenantId == tenantId);
        var res = await (from contract in items
                         select new Contract
                         {
                             ContractId = contract.ContractId,
                             PropertyId = contract.PropertyId,
                             TenantId = contract.TenantId,
                             Signed = contract.Signed,
                             Property = new Property
                             {
                                 Address = contract.Property.Address,
                                 User = new User
                                 {
                                     FirstName = contract.Property.User.FirstName,
                                     LastName = contract.Property.User.LastName,
                                     PhoneNumber = contract.Property.User.PhoneNumber
                                 }
                             }
                         }).ToListAsync();
        return res;
    }

    public async Task<Contract> GetContractById(int contractId)
    {
        var items = _context.Contracts.Include(i => i.Property).ThenInclude(i => i.User);
        var contract = items.Include(i => i.Tenant).Where(i => i.ContractId == contractId).FirstOrDefault();
        contract.ContractHtml.Replace("{{tenantFirstName}}", contract.Tenant.FirstName);
        contract.ContractHtml.Replace("{{tenantLastName}}", contract.Tenant.LastName);
        contract.ContractHtml.Replace("{{tenantAddress}}", contract.Tenant.Address);
        contract.ContractHtml.Replace("{{tenantPhoneNo}}", contract.Tenant.PhoneNumber);
        return contract;
    }

    public Task<Chat> GetChat(int tenantId, int landlordId)
    {
        return _context.Chats.Where(i => i.TenantId == tenantId && i.LandlordId == landlordId).FirstOrDefaultAsync();
    }

    public async Task<ChatLog> CreateChatLog(ChatLog chatLog)
    {
        _context.ChatLogs.Add(chatLog);
        await _context.SaveChangesAsync();
        return chatLog;
    }

    public Task<List<ChatLog>> GetChatLogsByChatId(int chatId)
    {
        return _context.ChatLogs.Include(i => i.Chat).Where(i => i.ChatId == chatId).ToListAsync();
    }

    public async Task<Contract> SignContract(int contractId)
    {
        var contract = _context.Contracts.Where(i => i.ContractId == contractId).FirstOrDefault();
        contract.Signed = true;
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<Property> UnlistProperty(int propertyId)
    {
        var property = _context.Properties.Where(i => i.PropertyId == propertyId).FirstOrDefault();
        property.Unlisted = true;
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<PropertyVisualization> CreateOrUpdatePropertyVisualization(int propertyId)
    {
        var visualization = _context.PropertyVisualizations.Where(i => i.PropertyId == propertyId && DateTime.Compare((DateTime)i.Date, DateTime.Now.Date) == 0).FirstOrDefault();
        if(visualization is null)
        {
            visualization = new PropertyVisualization()
            {
                Date = DateTime.Now.Date,
                PropertyId = propertyId,
                Views = 1
            };
            _context.PropertyVisualizations.Add(visualization);
            await _context.SaveChangesAsync();
            return visualization;
        }
        else
        {
            visualization.Views += 1;
            await _context.SaveChangesAsync();
            return visualization;
        }
    }

    public async Task<List<PropertyVisualization>> GetPropertyVisualizationsByPropertyId(int propertyId)
    {
        return await _context.PropertyVisualizations.Where(i => i.PropertyId == propertyId).ToListAsync();
    }
}

