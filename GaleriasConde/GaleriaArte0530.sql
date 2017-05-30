USE [master]
GO
/****** Object:  Database [GaleriasConde]    Script Date: 30/05/2017 14:32:57 ******/
CREATE DATABASE [GaleriasConde]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GaleriasConde', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GaleriasConde.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GaleriasConde_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GaleriasConde_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GaleriasConde] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GaleriasConde].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GaleriasConde] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GaleriasConde] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GaleriasConde] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GaleriasConde] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GaleriasConde] SET ARITHABORT OFF 
GO
ALTER DATABASE [GaleriasConde] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GaleriasConde] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GaleriasConde] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GaleriasConde] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GaleriasConde] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GaleriasConde] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GaleriasConde] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GaleriasConde] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GaleriasConde] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GaleriasConde] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GaleriasConde] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GaleriasConde] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GaleriasConde] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GaleriasConde] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GaleriasConde] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GaleriasConde] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GaleriasConde] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GaleriasConde] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GaleriasConde] SET  MULTI_USER 
GO
ALTER DATABASE [GaleriasConde] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GaleriasConde] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GaleriasConde] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GaleriasConde] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GaleriasConde] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GaleriasConde]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Artworks]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Artworks](
	[ArtworkID] [int] IDENTITY(1,1) NOT NULL,
	[onStock] [bit] NOT NULL,
	[img] [varbinary](max) NULL,
	[date] [nvarchar](max) NULL,
	[dimensions] [nvarchar](max) NULL,
	[Author_AuthorID] [int] NULL,
	[Type_TypeID] [int] NULL,
 CONSTRAINT [PK_dbo.Artworks] PRIMARY KEY CLUSTERED 
(
	[ArtworkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArtworkTranslations]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtworkTranslations](
	[ArtworkID] [int] NOT NULL,
	[lang] [nvarchar](128) NOT NULL,
	[isDefault] [bit] NOT NULL,
	[title] [nvarchar](max) NULL,
	[info] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ArtworkTranslations] PRIMARY KEY CLUSTERED 
(
	[ArtworkID] ASC,
	[lang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Authors]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[realName] [nvarchar](150) NULL,
	[artName] [nvarchar](150) NULL,
	[Nationality_NationalityID] [int] NULL,
 CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthorTranslations]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorTranslations](
	[AuthorID] [int] NOT NULL,
	[lang] [nvarchar](128) NOT NULL,
	[isDefault] [bit] NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AuthorTranslations] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC,
	[lang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[NationalityID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NationalityTranslations]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NationalityTranslations](
	[NationalityID] [int] NOT NULL,
	[lang] [nvarchar](128) NOT NULL,
	[isDefault] [bit] NOT NULL,
	[codNation] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NationalityTranslations] PRIMARY KEY CLUSTERED 
(
	[NationalityID] ASC,
	[lang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[codProfile] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[money] [float] NOT NULL,
	[comment] [nvarchar](max) NULL,
	[done] [bit] NOT NULL,
	[Artwork_ArtworkID] [int] NULL,
	[User_UserID] [int] NULL,
 CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Types]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Types] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeTranslations]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTranslations](
	[TypeID] [int] NOT NULL,
	[lang] [nvarchar](128) NOT NULL,
	[isDefault] [bit] NOT NULL,
	[codType] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TypeTranslations] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC,
	[lang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/05/2017 14:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[surnames] [nvarchar](max) NULL,
	[nick] [nvarchar](max) NULL,
	[pass] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[tlf] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[Nationality_NationalityID] [int] NULL,
	[Profile_ProfileID] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201705301034285_Migr0530', N'Galeria.Migrations.Configuration', 0x1F8B0800000000000400DD1DDB6EDCBAF1BD40FF41D0537B90B36B3B28706A78CF418E9D1C184DEC209B1CF4CDA057DCB5105DB692D6B551F4CBFAD04FEA2F94BA51BC5F44492B1B7989B9E470381C8E6686C399FFFDE7BF17BF3CC591F708B33C4C93957FBA38F13D986CD2204C762BFF506C7FFCC9FFE5E73FFEE1E27D103F79BFB7FDDE96FDD0C8245FF90F45B13F5F2EF3CD038C41BE88C34D96E6E9B6586CD278098274797672F2D7E5E9E91222103E82E579175F0E4911C6B0FA03FD7999261BB82F0E20FA940630CA9B76F4CBBA82EADD8018E67BB0812BFF3710C12C048BAB771F7DEF5D140284C21A465BDF03499216A040089E7FCBE1BAC8D264B7DEA306107D7DDE43D46F0BA21C36889F77DD4DD7707256AE61D90D6C416D0E7991C696004FDF364459B2C37B91D6C74443647B8FC85B3C97ABAE48B7F2DF65C53FD3ECBBEFB1739D5F4659D9AF236CB5058B66C01BAF697E83371FF148F9EF8D7779888A430657093C141988DE789F0FF751B8F91B7CFE9A7E87C92A3944118915C20BFD4635A0A6CF59BA8759F1FC056E695CAFAF7C6F490F5FB2E3F1687E68BDA8EBA4787BE67B370815701F41CC020401D6459AC1DF60023350C0E033280A98A11DBC0E6045440E0966CA34410036DFDB097F4DD308824430A51A4C18EF30883001199AF71378FA08935DF1B0F2D17F7DEF43F80483B6C508688056D44245E7019D6933A8DF9210890034A8C80EFA49D0414E4ACEC8879FEA063C86BB6A9BD88D3E140F69E67B5F6054FD9C3F84FB5A0E2CEA9FEE1A5640487DC8D2F84B1AE151F8A7BBAF20DBC102A19D8A7F5FA7876C6381D5D70C2439D814353104B8111DEEF091ECF013FCCCE128EA638D27DA2631EDDA49AB0E04E188763C1BA61AF9638B2E89CAC5B293476A29D5ECAAB190AAFA1F45465533F7125178E454122A83202AFFA7389EA77F3919401280AC18671EB918C087DC4D10702C2D1114A678DD548D20AA76478E1AD58DC38EF8558620D9C5E9E45198981E3F62D031CE20317D9F83C80C1FE7341A6F0021D6CD378018748C0D20A6EFB301CCF0A9C4619C26F0B99DEE2A45A480D6DA1AD2BF91D2538CAF5B215CAD354B9DB41C4A336165924A7BE977262A2DC4F830A0B6A39C02346F2FF66FC61D59F0343B556D5EC3159602A81EB510009A95F528EC1D81F2DC8E6666AA4F773DB95C593AFBC94884D85A9AF915DC02447D579315315234BE791926DB744AC3522123051C2E92958A6E32DB49D87700536A8053CDC19993B935E49936B4CB5EF5910E60BEC9C27DAD85CEC799431F8FA6376B2F093A49CC2651CFA1AC27F7132701363B0B6BC0B367658ABDEA038870B801131F3F9DB342C29032EF854177EE5C9A8C713AA168C9DB30B2B0269A01C73875CDD47D6C0A62E854E634E2384CDC4159D6CA4C7417BB2C94F99892030A5A339BF3B54BD8DAAF30997C95DEB6B02CC75DBB083BF07E17612F2771F92D8716D73065EF631C9772DE3E52B21D3795884CD49722C3D8C9F9212BE719E112965D4DD8DD768F36C91EE4E3AF040441062798A728A353469E03C6208C66A43496674CA621B2BF71128DEB607BFF8635121966B8038355D32EC6A8FDD146B4BECBF37413563850D66E772D492FE97D12789A3BCA7A8B3BEB18ED3312B0E11E895484C0CA3F592C4E3952C9E1E20003026EEBD4A201FFC02E99589CD19A497ED0A027640FDDCA7FD02F5BC455045C8A637564B52080E87A4586A9F2AEA54395BA3134A78332C644CB024E44A0A24BA4FB240C35B1E54D3948C15A6BB56BF8850A1DC51A24D55E638E0CB4DD634D12A5DF594FF4539F55D26E932B18C1027AEF367520E425C83720E03F2C485C06740BD2EB60562A5420BA44E8204D314C0A5E090C934DB80791F93A1810D697464B3C27FBCB15DCC3A4D401CDB7D019193C27434E1DF5AC85B5C8E7AA96AD4A072C2BBA7B33AED683ABFD4ACC806B758B306213F99D8805CBEA76CE159309F8D5C43F2963272B67A5504DE8CBC8362E4F3305E5F87C6DB12613BED25D3F98B3B9C5360F82D8045C2F761E49B53EB52789D685FAB2B4DA11A551B88ECFBD4AF44DD842EABE356754E53EB9E130014F7246BF8C53E41E808E496A1FA439F7499D06139877944F418920E760705C30EB9320E0611F47EF85D62E0DC41505E20998358B6D1CBD65337C2A046E628458E329CE1BB712BB8412EC1A165C1477E743610D0F8E0A0C884A0511426874400D808E3342280243718E0616FD0C84034519EE3A50251145302A09AA238AC846949198EE65446E1D604127E35D78D60097F6D4CCD01C0A11487C5E0CF644831DDF4503B33CCB2240B54C600613A795DD12E2B503D14BF22082FD44E87D8F186DE2C4715F1ABDAB910483F1653FEAF42ACD29409D542911A45F295367643F5288BE4F0424460A39934418D5CDD344EB9D34F64F126BA1A5A082342A8FE4489C423D7313F088D451A977551A60AC774E9264ACBF0043AD591CBC2A2581DE8569EDC4E409A49294D65ECB31658B300E512662B40E344B171A2770CCC9A6F599E985590F9A19C58DF1D4B376E7F476E80805AF529DE8EDC11953C68BA34804525EEF31B0F0193022CA986A6A27C108828FBF89E649A3365CCD4C5702F5469B5350416AAC8EC828F4C5B784084223566FC6DA2F9E355C09089D8E6EBCE6F6FA1DDBAAF8B78B659D43A469B8584A928D5C7C02FB7D98EC88E4234D8BB7AE338F5CFEB8B6CFCC11D730961B4ADD662D6B3C5391666007995FD1D408D30F61961757A000F7A08CDBB80C62AE1B63994B4C8E7632C6F8E6F7ABB545DA01E5FF29174099846521D10A3AFA7D404B2A5F4B56AB83FCF7991FE995895F400432F9BBABCB343AC489F6C24C0E0BE7ED2021E146733855E20E1246D5603EBECED14102A85B2C201009382838443B0FED62C96C0FE730E41880F3BAD20C65C66E8D7AD19BDB848A9409B349064A790D5F6A51AC26BDEA9243EAF22F9090BA56734838C102090837CE668FE90F57DF9D567C8E0DB65B395A465FE65E87A4B2E6CAE768B4A6ACECBEA4263D92F6A4568E96919A79FC4F925A99564005B379D94FC26A9ACC61E097FD2414DC682194AB97FB9438AE5AE6C338957ADD9B6304A68309AB08874979A4B9CBA2984372BF75BC0F9AC087E1A84AA96099AB556A2853A858F54B11128CE8D58A0A02F1EA8352B1BA667358CD7375124ED364814FF5189D42A56A990F37F29E21374DCB95170D808CAF81CD8B11A947D6D41782FC61362C25738D0DA0D739329731A431F4BD97C16BC47B625AA1C1CDB3E133ECF5E9CB5812D79501234947CAC84ABCB325C92A7DB9ABD922EC9463F64872237DC44DE25CBD2E0AA4E3F1D7831846B17C3127BD76FC333C248A14392203D5DEE1BE5C538543D8738A78988C92EDF3509290E2A7A62A2809E7A8492CBD3DDD8B4E124AD76A814BC83A3AEB167308F57B4C1242DD62E1BB6A1F5B52BEABB6D1428D2F1F53524A7CD9603EBE79284942689AA63F23F47586489327E279545A3AD1CDD0C95E5EC708F56D2EE887A78AB5B67EA77A214020628FA3343A7720E35689DE659A046115057A9D97CFC7F19B5A0B0AB0775A7DF984BAE054B20AD5D3CC4B2EDF08A3C87E07DDFB4EA387F7631FA3B0FF416C5277FE31268633270983C5B40EE3AEAB855F58B0358A28B0414EF75DDF536E86AA1D1BF5F77E0F209074F470174954789DD2D5D9F471F86809C2E74C37416205DCC9DF50D8091B4178E08C3F548AA53B73041F8323D7EFD51F28912A2FA0BD2CBE66CE1F2759649121CE3666CB4BFA2CD1614B0ABEC17D5C7886094B32A4BDDA1F74F759EE17EAC3234CF0D52CF943BB743D5F70315D6C176C9E352DF86F1CD3D5C453E9AB4A7101567517DF43F83F8641195CB57ECE0B182FCA0E8BF53FA2CB28ACAE84DB0E9F40126E615ED429ADFCB393D333A63ED57C6A452DF33CA0326EC90B46D17B3679FDA6B024B136FD96650A38A664D37D58B8946B7A04D97D55B1E94F3178FA3309C928C33F51A22941A0360F20EB07882BC3E4048E335B89FDE01EFC5D27017C5AF9FFAAC69E7BD77FBF6386BFF16E337446CEBD13EFDFB698507A891D16C450730C6CAB15F5392183550F1AE57CB005835A46E24BF9D8ED24531F6828B00A55C48E5DA48046601EF92BE9A3D5BE1980977A95BBE9B17CA591DCB3F2CC2847892A36B38D5260FFA9616ACDB87D24887A327D3E7B02DF81E577810530C2D1E283CCA62CE432E529D2467ACDB8648A25C7C839C53A69B1F8BB53A62D76CD49DCE74815641515A7C34D564AB100E452526440DD67485E73525A5F2DA7098A7B8CC1264651592FA0FE440FADF1D5B20E5796620CC61146614D5F3261143D90AF92300605D51151B3AC416063CABFE6E3D5DD958DC31ABC0F7CCA1CFBA39CA944E04BE8A538B1A9F39D8091E9F19D009129F09D003169EE9D6011A9EC9DE050E9EA9D20CDC9FB23FDBADC89BF3206587100DC0D66D794F403A4A027A34B6CF37A3B64DC9D30AFAEF451BC6C42658CDC64599F6D93E6F6CFAED88FB1066207F5DB627B43C436E1B2EDA4FA48832932CE5AD430B038E11AD6A0B22512D0ACCA1FB8E4969F3081BCFA1DB674567568DB14B2C3A4B003A9E15A945D38F287835F92642FE44163A37C3434816AD36D7A9F221793D79650A69073AFABF142C48BD9F372CBD9675C9062EA5A10AA8C7BCE25305E86DA6BF266DC6EEE975340E228751AB4E90887A95BF1C2B46CF337E63DB09865718769EB2BC8D3393A169398BD8EA676B15BCF3BA7A20CC39BF575F672029459898317266C248F92E76FD01B55AD60AEADEC2A4B1C8D1B84AB926C8B323A7F782E307A1430F8EE33A1F40D2E7C5E5176F3E83205D856EB3CCBAC155707CEAFFCE0BE0C46A97DD3D244DC1CFC4649E7C1373F08A14B3256B3C02939C6CD40BF3A124CA34EC7CB4E46B9A7B8C9A85F4593A992E70B0B52486B8408A13F8B522B4B36BB4FF91005134C536744CE2753D72351B352AFE225AADA25A2E93ECBF2298B18C9BAB2898CC1ACEB9F48CB9F88661066999EAC328A2063BE408A0BFC5E8237AE9A7751E60B1CB2F0894056726955950B3625D35C8A9A58EC90FC7A42F2F87D801D1EA66009F9A1E8F2711E917127AC4962BDB38ACF9F69F192F9161AB11660D20FB161419217583FA497E0D3680C36C546E6560BC44E72C87409A38A21C72FF3E1CA07A442D33D421F689958DBEB5DC483D124A92C88632ECBA24E07FF761B99BF07343AAEA39990059E87BB0E44F92E3D811BCAF0C57DAE936DDA9AE20C466D172672EB132C4080AC6224E6C32DFA90A39F3730CFC33286F477101D5097F7F13D0CAE93DB43B13F1468C930BE8F28AE28ED78D5FC5531121AE78BDB2A403F1F620908CDB07C5F7C9BFC7A08A300E3FD41F0E44802A2741034219BE55E1665E8E6EE1943BAE1729ACB0035E4C37E8DAF30DEA3C30FF3DB640D1E611FDC10EB7D843BB0796E9FE0CB81E8378226FBC55508761988F30646371EFD897838889F7EFE3F3ECB5D793EAB0000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Artworks] ON 

INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (1, 1, NULL, N'1503', N'77cm x 53cm', 3, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (2, 1, NULL, N'1888', N'72 cm × 90 cm', 6, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (3, 1, NULL, N'1889', N'73,7 cm × 92,2 cm', 6, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (4, 1, NULL, N'1890', N'94 cm × 74 cm', 6, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (5, 1, NULL, N'1893', N'91 cm × 74 cm', 8, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (6, 1, NULL, N'1819-1823', N'146 cm × 83 cm', 1, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (7, 1, NULL, N'1937', N'776,6 cm × 349 cm', 2, 1)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (8, 1, NULL, N'1960', N'Tamaño natural', 9, 2)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (9, 1, NULL, N'1513-1515', N'235 cm', 4, 2)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (10, 1, NULL, N'1498-1499', N'174 x 195 cm', 4, 2)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (11, 1, NULL, N'1501-1504', N'5,17 m de altura', 4, 2)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (12, 1, NULL, N'1902', N'1,89 m x 98 cm x 1,4 m', 5, 2)
INSERT [dbo].[Artworks] ([ArtworkID], [onStock], [img], [date], [dimensions], [Author_AuthorID], [Type_TypeID]) VALUES (13, 1, NULL, N'1495-1497', N'880 cm × 460 cm', 3, 5)
SET IDENTITY_INSERT [dbo].[Artworks] OFF
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (1, N'en-US', 0, N'La Gioconda', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (1, N'es-ES', 1, N'La Gioconda', N'El Retrato de Lisa Gherardini, esposa de Francesco del Giocondo, más conocido como La Gioconda, también conocida como La Mona Lisa. Su nombre, La Gioconda (la alegre, en castellano), deriva de la tesis más aceptada acerca de la identidad de la modelo: la esposa de Francesco Bartolomeo de Giocondo, que realmente se llamaba Lisa Gherardini, de donde viene su otro nombre: Mona (señora, del italiano antiguo) Lisa.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (2, N'en-US', 0, N'El dormitorio de Arlés', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (2, N'es-ES', 1, N'El dormitorio de Arlés', N'El grito es el título de cuatro cuadros de Edvard Munch. La versión más famosa se encuentra en la Galería Nacional de Noruega. El cuadro es abundante en colores cálidos de fondo, luz semioscura y la figura principal es una persona en un sendero con vallas. Esta figura está gritando, con una expresión de desesperación. En el fondo, casi fuera de escena, se aprecian dos figuras con sombrero que no se pueden distinguir con claridad. El cielo, al igual que el fondo, parece fluido y arremolinado.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (3, N'en-US', 0, N'La noche estrellada', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (3, N'es-ES', 1, N'La noche estrellada', N'El cuadro muestra la vista exterior durante la noche desde la ventana del cuarto del sanatorio de Saint-Rémy-de-Provence, donde el autor se recluyó hacia el final de su vida. Sin embargo, la obra fue pintada durante el día, de memoria.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (4, N'en-US', 0, N'La iglesia de Auvers-sur-Oise', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (4, N'es-ES', 1, N'La iglesia de Auvers-sur-Oise', N'Después de que Van Gogh dejase el hospital de Saint-Rémy-de-Provence, se marchó a Auvers-sur-Oise, por consejo de un amigo, para que lo tratase el doctor. Aquí pasó lo que serían sus últimas diez semanas de vida y en este breve lapso de tiempo pintó un centenar de cuadros. Comenzó por las flores del jardín del doctor, y luego fue dedicándose a la población y su entorno. Así descubrió la iglesia del pueblo, de estilo gótico, que pintó en este cuadro: La iglesia de Auvers-sur-Oise.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (5, N'en-US', 0, N'El grito', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (5, N'es-ES', 1, N'El grito', N'El autor realizó 4 versiones de esta obra, siendo esta la más famosa. Constituye una imagen de icono cultural, al igual que La Gioconda, de da Vinci. Todas las versiones del cuadro muestran una figura andrógina en primer plano, que simboliza a un hombre moderno en un momento de profunda angustia y desesperación existencial. El paisaje del fondo es Oslo visto desde la colina de Ekeberg.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (6, N'en-US', 0, N'Saturno devorando a un hijo', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (6, N'es-ES', 1, N'Saturno devorando a un hijo', N'Es una de las pinturas que formaron parte de la decoración de los muros de la casa que Goya adquirió en 1819. Por tanto, la obra pertenece a la serie de las Pinturas negras. Representa al dios Crono, como es habitual indiferenciado de Chronos, o Saturno en la mitología romana, en el acto de devorar a uno de sus hijos. La figura era emblema alegórico del paso del tiempo, pues Crono se comía a los hijos recién nacidos de Rea, su mujer, por temor a ser destronado por uno de ellos.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (7, N'en-US', 0, N'Guernica', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (7, N'es-ES', 1, N'Guernica', N'Famoso cuadro de Pablo Picasso, pintado entre mayo y junio de 1937. Alude al bombardeo de Guernica, ocurrido el 26 de abril de dicho año, durante la Guerra Civil Española. Fue realizado por encargo del Director General de Bellas Artes a petición del Gobierno de la Segunda República Española para ser expuesto en el pabellón español durante la Exposición Internacional de 1937 en París, con el fin de atraer la atención del público hacia la causa republicana en plena Guerra Civil Española.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (8, N'en-US', 0, N'L''''Homme qui marche I', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (8, N'es-ES', 1, N'L''''Homme qui marche I', N'Giacometti realizó durante 1960 hasta 40 versiones de ese hombre que camina y, al final, se decidió por dos y destruyó todas las demás. La pieza se moldeó en bronce en 1961, y no es única. Forma parte de una edición de seis.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (9, N'en-US', 0, N'Moisés', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (9, N'es-ES', 1, N'Moisés', N'Originariamente concebida para la tumba del papa Julio II en la Basílica de San Pedro, el Moisés y la tumba se colocaron finalmente en la iglesia menor de San Pietro in Vincoli, en la zona del Esquilino, tras la muerte del papa. La estatua se representa con cuernos en su cabeza. Se cree que esta característica procede de un error en la traducción por parte de San Jerónimo del capítulo del Éxodo 34:29-65.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (10, N'en-US', 0, N'La Piedad', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (10, N'es-ES', 1, N'La Piedad', N'Se encuentra en la Basílica de San Pedro de la Ciudad del Vaticano. Esta obra es de bulto redondo, lo que significa que se puede ver en todos los ángulos, pero el punto de vista preferente es el frontal.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (11, N'en-US', 0, N'David', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (11, N'es-ES', 1, N'David', N'Realizada por encargo de la Opera del Duomo de la catedral de Santa María del Fiore de Florencia. La escultura representa al rey David bíblico en el momento previo a enfrentarse con Goliat, y fue acogida como un símbolo de la República de Florencia frente a la hegemonía de sus derrocados dirigentes, los Médici, y la amenaza de los estados adyacentes, especialmente los Estados Pontificios.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (12, N'en-US', 0, N'El pensador', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (12, N'es-ES', 1, N'El pensador', N'Esta pieza, denominada originalmente El poeta, se concibió a partir de una comisión que el Ministerio de Bellas Artes encargó a Rodin para el futuro Museo de las Artes Decorativas de París. En su origen, buscaba representar a Dante en la puerta del infierno. Rodin deseaba mostrar en el desnudo de esta escultura a una figura heroica al estilo de Miguel Ángel para representar tanto el pensar como la poesía. La referencia a Il penseroso de Miguel Ángel ha sido destacada por varios críticos.')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (13, N'en-US', 0, N'La última cena', N'Soon in english')
INSERT [dbo].[ArtworkTranslations] ([ArtworkID], [lang], [isDefault], [title], [info]) VALUES (13, N'es-ES', 1, N'La última cena', N'No es un fresco tradicional, sino un mural ejecutado al temple y óleo sobre dos capas de preparación de yeso extendidas sobre enlucido. Muchos expertos e historiadores del arte consideran La última cena como una de las mejores obras pictóricas del mundo. Representa el momento más dramático, la escena de la última cena de Jesús de Nazaret, cuando anuncia que uno de sus doce discípulos le traicionará, según se narra en el Nuevo Testamento.')
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (1, N'Francisco de Goya y Lucientes', N'Goya', 1)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (2, N'Pablo Ruiz Picasso', N'Picasso', 1)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (3, N'Leonardo di ser Piero da Vinci', N'Leonardo da Vinci', 2)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (4, N'Michelangelo Buonarroti', N'Miguel Ángel', 2)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (5, N'François-Auguste-René Rodin', N'Auguste Rodin', 3)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (6, N'Vincent Willem van Gogh', N'Vincent van Gogh', 5)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (7, N'Rembrandt Harmenszoon van Rijn', N'Rembrandt', 5)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (8, N'Edvard Munch', N'Edvard Munch', 6)
INSERT [dbo].[Authors] ([AuthorID], [realName], [artName], [Nationality_NationalityID]) VALUES (9, N'Alberto Giacometti', N'Alberto Giacometti', 7)
SET IDENTITY_INSERT [dbo].[Authors] OFF
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (1, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (1, N'es-ES', 1, N'Su obra abarca la pintura de caballete y mural, el grabado y el dibujo. En todas estas facetas desarrolló un estilo que inaugura el Romanticismo. El arte goyesco supone, asimismo, el comienzo de la pintura contemporánea y es precursor de las vanguardias pictóricas del siglo XX; por todo ello, se le considera uno de los artistas españoles más relevantes y uno de los grandes maestros de la historia del arte.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (2, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (2, N'es-ES', 1, N'Es considerado desde el génesis del siglo XX como uno de los mayores pintores que participaron en muchos movimientos artísticos que se propagaron por el mundo y ejercieron una gran influencia en otros grandes artistas de su tiempo. Sus trabajos están presentes en museos y colecciones de toda Europa y del mundo. Además, abordó otros géneros como el dibujo, el grabado, la ilustración de libros, la escultura, la cerámica y el diseño de escenografía y vestuario para montajes teatrales.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (3, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (3, N'es-ES', 1, N'Fue a la vez pintor, anatomista, arquitecto, paleontólogo,3 artista, botánico, científico, escritor, escultor, filósofo, ingeniero, inventor, músico, poeta y urbanista.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (4, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (4, N'es-ES', 1, N'Arquitecto, escultor y pintor italiano renacentista, considerado uno de los más grandes artistas de la historia tanto por sus esculturas como por sus pinturas y obra arquitectónica. Desarrolló su labor artística a lo largo de más de setenta años entre Florencia y Roma, que era donde vivían sus grandes mecenas, la familia Médici de Florencia y los diferentes papas romanos.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (5, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (5, N'es-ES', 1, N'Procedente del academicismo de la escuela escultórica neoclásica, no solo fue el escultor encargado de poner fin a más de dos siglos de búsqueda de la mimesis en las artes tridimensionales, sino que además dio un nuevo rumbo a la concepción del monumento y la escultura pública. Debido a esto, Rodin ha sido denominado en la historia del arte como «el primer escultor moderno».')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (6, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (6, N'es-ES', 1, N'Uno de los principales exponentes del postimpresionismo. Pintó unos 900 cuadros(entre ellos 27 autorretratos y 148 acuarelas) y realizó más de 1600 dibujos. Autodidacta.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (7, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (7, N'es-ES', 1, N'La historia del arte le considera uno de los mayores maestros barrocos de la pintura y el grabado, siendo con seguridad el artista más importante de la historia de los Países Bajos. Su aportación a la pintura coincide con lo que los historiadores han dado en llamar la edad de oro neerlandesa, el considerado momento cumbre de su cultura, ciencia, comercio, poderío e influencia política.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (8, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (8, N'es-ES', 1, N'El pintor decía de sí mismo que, del mismo modo que Leonardo da Vinci había estudiado la anatomía humana y diseccionado cuerpos, él intentaba diseccionar almas. Por ello, los temas más frecuentes en su obra fueron los relacionados con los sentimientos y las tragedias humanas. Se le considera precursor del expresionismo.')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (9, N'en-US', 0, N'Pendiente de traducción')
INSERT [dbo].[AuthorTranslations] ([AuthorID], [lang], [isDefault], [description]) VALUES (9, N'es-ES', 1, N'Giacometti nació en Borgonovo, Val Bregaglia, en Suiza, cerca de la frontera italiana, donde creció en un ambiente de artistas. Su padre, Giovanni Giacometti, había sido pintor impresionista, mientras que su padrino, Cuno Amiet, fue fauvista.')
SET IDENTITY_INSERT [dbo].[Nationalities] ON 

INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (1)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (2)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (3)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (4)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (5)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (6)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (7)
INSERT [dbo].[Nationalities] ([NationalityID]) VALUES (8)
SET IDENTITY_INSERT [dbo].[Nationalities] OFF
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (1, N'en-US', 0, N'Spain')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (1, N'es-ES', 1, N'España')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (2, N'en-US', 0, N'Italy')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (2, N'es-ES', 1, N'Italia')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (3, N'en-US', 0, N'France')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (3, N'es-ES', 1, N'Francia')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (4, N'en-US', 0, N'Germany')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (4, N'es-ES', 1, N'Alemania')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (5, N'en-US', 0, N'Netherlands')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (5, N'es-ES', 1, N'Países Bajos')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (6, N'en-US', 0, N'Norway')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (6, N'es-ES', 1, N'Noruega')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (7, N'en-US', 0, N'Switzerland')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (7, N'es-ES', 1, N'Suiza')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (8, N'en-US', 0, N'Venezuela')
INSERT [dbo].[NationalityTranslations] ([NationalityID], [lang], [isDefault], [codNation]) VALUES (8, N'es-ES', 1, N'Venezuela')
SET IDENTITY_INSERT [dbo].[Profiles] ON 

INSERT [dbo].[Profiles] ([ProfileID], [codProfile]) VALUES (1, N'Default')
INSERT [dbo].[Profiles] ([ProfileID], [codProfile]) VALUES (2, N'User')
INSERT [dbo].[Profiles] ([ProfileID], [codProfile]) VALUES (3, N'Admin')
INSERT [dbo].[Profiles] ([ProfileID], [codProfile]) VALUES (4, N'Master')
SET IDENTITY_INSERT [dbo].[Profiles] OFF
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([TypeID]) VALUES (1)
INSERT [dbo].[Types] ([TypeID]) VALUES (2)
INSERT [dbo].[Types] ([TypeID]) VALUES (3)
INSERT [dbo].[Types] ([TypeID]) VALUES (4)
INSERT [dbo].[Types] ([TypeID]) VALUES (5)
SET IDENTITY_INSERT [dbo].[Types] OFF
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (1, N'en-US', 0, N'Painting')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (1, N'es-ES', 1, N'Cuadro')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (2, N'en-US', 0, N'Sculpture')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (2, N'es-ES', 1, N'Escultura')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (3, N'en-US', 0, N'Engrave')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (3, N'es-ES', 1, N'Grabado')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (4, N'en-US', 0, N'Drawing')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (4, N'es-ES', 1, N'Dibujo')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (5, N'en-US', 0, N'Mural')
INSERT [dbo].[TypeTranslations] ([TypeID], [lang], [isDefault], [codType]) VALUES (5, N'es-ES', 1, N'Mural')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (1, N'master', N'master', N'master', N'master', N'Local', N'988776655', N'master@gmail.com', 1, 4)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (2, N'Hermes', N'Iglesias Viera', N'admin1', N'Asd123', N'Via Giacinto Gigante, 8', N'609876543', N'admin1@hotmail.com', 2, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (3, N'Marcella', N'Napolitano', N'mnapo', N'Asd123', N'Herrenberg 92', N'091 824 41 96', N'MarcellaNapolitano@dayrep.com', 7, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (4, N'Ismael', N'Conde Iglesias', N'condscorpio', N'Asd123', N'Galicia', N'689032232', N'condscorpio@gmail.com', 1, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (5, N'Laura', N'Jager', N'ljager', N'Asd123', N'Billwerder Neuer Deich 57', N'09277 61 53 76', N'LauraJager@rhyta.com', 4, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (6, N'Carlos', N'The boss', N'cfgcarlos', N'Asd123', N'Derecha', N'689098765', N'cfgcarlos@gmail.com', 1, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (7, N'Charlot', N'St-Jean', N'Thiets82', N'Asd123', N'88, avenue de Bouvines', N'01.18.06.99.16', N'CharlotSt-Jean@jourrapide.com', 3, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (8, N'Benigno', N'Feijoo Otero', N'mali92', N'Asd123', N'Galicia', N'677329102', N'mali92@gmail.com', 1, 2)
INSERT [dbo].[Users] ([UserID], [name], [surnames], [nick], [pass], [address], [tlf], [email], [Nationality_NationalityID], [Profile_ProfileID]) VALUES (9, N'Luis Emilio', N'Fernández López', N'exodus360', N'Asd123', N'Izquierda', N'640736533', N'exodus360@gmail.com', 8, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_Author_AuthorID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Author_AuthorID] ON [dbo].[Artworks]
(
	[Author_AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Type_TypeID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Type_TypeID] ON [dbo].[Artworks]
(
	[Type_TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArtworkID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_ArtworkID] ON [dbo].[ArtworkTranslations]
(
	[ArtworkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Nationality_NationalityID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Nationality_NationalityID] ON [dbo].[Authors]
(
	[Nationality_NationalityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuthorID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_AuthorID] ON [dbo].[AuthorTranslations]
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NationalityID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_NationalityID] ON [dbo].[NationalityTranslations]
(
	[NationalityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Artwork_ArtworkID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Artwork_ArtworkID] ON [dbo].[Transactions]
(
	[Artwork_ArtworkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_UserID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_User_UserID] ON [dbo].[Transactions]
(
	[User_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TypeID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_TypeID] ON [dbo].[TypeTranslations]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Nationality_NationalityID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Nationality_NationalityID] ON [dbo].[Users]
(
	[Nationality_NationalityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Profile_ProfileID]    Script Date: 30/05/2017 14:32:57 ******/
CREATE NONCLUSTERED INDEX [IX_Profile_ProfileID] ON [dbo].[Users]
(
	[Profile_ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artworks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Artworks_dbo.Authors_Author_AuthorID] FOREIGN KEY([Author_AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Artworks] CHECK CONSTRAINT [FK_dbo.Artworks_dbo.Authors_Author_AuthorID]
GO
ALTER TABLE [dbo].[Artworks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Artworks_dbo.Types_Type_TypeID] FOREIGN KEY([Type_TypeID])
REFERENCES [dbo].[Types] ([TypeID])
GO
ALTER TABLE [dbo].[Artworks] CHECK CONSTRAINT [FK_dbo.Artworks_dbo.Types_Type_TypeID]
GO
ALTER TABLE [dbo].[ArtworkTranslations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArtworkTranslations_dbo.Artworks_ArtworkID] FOREIGN KEY([ArtworkID])
REFERENCES [dbo].[Artworks] ([ArtworkID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArtworkTranslations] CHECK CONSTRAINT [FK_dbo.ArtworkTranslations_dbo.Artworks_ArtworkID]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Authors_dbo.Nationalities_Nationality_NationalityID] FOREIGN KEY([Nationality_NationalityID])
REFERENCES [dbo].[Nationalities] ([NationalityID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_dbo.Authors_dbo.Nationalities_Nationality_NationalityID]
GO
ALTER TABLE [dbo].[AuthorTranslations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AuthorTranslations_dbo.Authors_AuthorID] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthorTranslations] CHECK CONSTRAINT [FK_dbo.AuthorTranslations_dbo.Authors_AuthorID]
GO
ALTER TABLE [dbo].[NationalityTranslations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NationalityTranslations_dbo.Nationalities_NationalityID] FOREIGN KEY([NationalityID])
REFERENCES [dbo].[Nationalities] ([NationalityID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NationalityTranslations] CHECK CONSTRAINT [FK_dbo.NationalityTranslations_dbo.Nationalities_NationalityID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.Artworks_Artwork_ArtworkID] FOREIGN KEY([Artwork_ArtworkID])
REFERENCES [dbo].[Artworks] ([ArtworkID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.Artworks_Artwork_ArtworkID]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.Users_User_UserID] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.Users_User_UserID]
GO
ALTER TABLE [dbo].[TypeTranslations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TypeTranslations_dbo.Types_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Types] ([TypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeTranslations] CHECK CONSTRAINT [FK_dbo.TypeTranslations_dbo.Types_TypeID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Nationalities_Nationality_NationalityID] FOREIGN KEY([Nationality_NationalityID])
REFERENCES [dbo].[Nationalities] ([NationalityID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Nationalities_Nationality_NationalityID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Profiles_Profile_ProfileID] FOREIGN KEY([Profile_ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Profiles_Profile_ProfileID]
GO
USE [master]
GO
ALTER DATABASE [GaleriasConde] SET  READ_WRITE 
GO
