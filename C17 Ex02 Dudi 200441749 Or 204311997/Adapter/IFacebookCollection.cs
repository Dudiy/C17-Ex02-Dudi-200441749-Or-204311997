using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Adapter
{
    interface IFacebookCollection<T>
    {
        Album[] AlbumsToLoad { get; set; }
        //FacebookObjectCollection<T> FetchDataWithProgressBar();
        FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar();

        FacebookObjectCollection<T> UnboxCollection(FacebookObjectCollection<FacebookObject> i_Collection);
    }
}
