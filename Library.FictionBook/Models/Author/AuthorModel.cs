using System;
using System.Xml.Linq;
using Library.FictionBook.Models.Core;
using Library.FictionBook.Models.Interfaces;

namespace Library.FictionBook.Models.Author
{
    public class AuthorModel : IModel
    {
        #region Private Members

        private TextFieldModel _uid = new TextFieldModel();

        #endregion

        public TextFieldModel FirstName { get; set; }
        public TextFieldModel MiddleName { get; set; }
        public TextFieldModel LastName { get; set; }
        public TextFieldModel Uid
        {
            get
            {
                return _uid;
            }
            set
            {
                if (!string.IsNullOrEmpty(value.Text))
                {
                    _uid = value;
                    _uid.Text = _uid.Text.ToLower();
                }
                else
                {
                    _uid = value;
                }
            }
        }
        public TextFieldModel NickName { get; set; }
        public TextFieldModel HomePage { get; set; }
        public TextFieldModel Email { get; set; }

        #region Implementaion of IModel
        
        public XNamespace BookNamespace { get; set; }

        public virtual void Load(XNode author)
        {
            Clear();

            var eAuthor = author as XElement;

            if (eAuthor == null)
                throw new ArgumentNullException(nameof(eAuthor));

            #region FirstName
            
            var firstName = eAuthor.Element(BookNamespace + FictionBookConstants.FirstName);
            if (firstName != null) 
            {
                FirstName = new TextFieldModel();

                try
                {
                    FirstName.Load(firstName);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region MiddleName

            var middleName = eAuthor.Element(BookNamespace + FictionBookConstants.MiddleName);
            if (middleName != null)
            {
                MiddleName = new TextFieldModel();

                try
                {
                    MiddleName.Load(middleName);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region LastName

            var lastName = eAuthor.Element(BookNamespace + FictionBookConstants.LastName);
            if (lastName != null) 
            {
                try
                {
                    LastName = new TextFieldModel();
                    LastName.Load(lastName);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region NickName

            var nickName = eAuthor.Element(BookNamespace + FictionBookConstants.NickName);
            if (nickName != null)
            {
                try
                {
                    NickName = new TextFieldModel();
                    NickName.Load(nickName);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region HomePage

            var homePage = eAuthor.Element(BookNamespace + FictionBookConstants.HomePage);
            if (homePage != null) 
            {
                try
                {
                    HomePage = new TextFieldModel();
                    HomePage.Load(homePage);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region Email

            var email = eAuthor.Element(BookNamespace + FictionBookConstants.Email);
            if (email != null) 
            {
                try
                {
                    Email = new TextFieldModel();
                    Email.Load(email);
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

            #region Uid

            var uid = eAuthor.Element(BookNamespace + FictionBookConstants.Id);
            if (uid != null) 
            {
                Uid = new TextFieldModel();
                try
                {
                    Uid.Load(uid);
                    Uid.Text = _uid.Text.ToLower();
                }
                catch (Exception)
                {
                    //
                }
            }

            #endregion

        }
        public virtual XNode Save(string name = FictionBookConstants.Author)
        {
            var eAuthor = new XElement(FictionBookSchemaConstants.DefaultNamespace + name);

            #region FirstName

            if (FirstName != null)
                eAuthor.Add(FirstName.Save(FictionBookConstants.FirstName));

            #endregion

            #region MiddleName

            if (MiddleName != null)
                eAuthor.Add(MiddleName.Save(FictionBookConstants.MiddleName));

            #endregion

            #region LastName

            if (LastName != null)
                eAuthor.Add(LastName.Save(FictionBookConstants.LastName));

            #endregion

            #region NickName

            if (NickName != null)
                eAuthor.Add(NickName.Save(FictionBookConstants.NickName));

            #endregion

            #region HomePage

            if (HomePage != null)
                eAuthor.Add(HomePage.Save(FictionBookConstants.HomePage));

            #endregion

            #region Email

            if (Email != null)
                eAuthor.Add(Email.Save(FictionBookConstants.Email));

            #endregion

            #region Uid

            if (Uid != null)
                eAuthor.Add(Uid.Save(FictionBookConstants.Id));

            #endregion

            return eAuthor;
        }

        public void Clear()
        {
            FirstName = null;
            MiddleName = null;
            LastName = null;
            NickName = null;
            HomePage = null;
            Email = null;
            Uid = null;
        } 

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ToString().Equals(obj.ToString());
        }

        public override string ToString()
        {
            string firstName = "";
            if (FirstName != null)
            {
                firstName = FirstName.Text;
            }

            string midName = "";
            if (MiddleName != null)
            {
                midName = MiddleName.Text;
            }

            string lastName = "";
            if (LastName != null)
            {
                lastName = LastName.Text;
            }

            string nickName = "no nick";
            if (NickName != null)
            {
                nickName = NickName.Text;
            }

            string uid = "unknown-uid";
            if (Uid != null)
            {
                uid = Uid.Text;
            }

            return string.Format("{0} {1} {2} ({3}): {4}", lastName, firstName, midName, nickName, uid);
        }

        #endregion
    }
}
