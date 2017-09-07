/*
 * C17_Ex01: IFacebookCollection.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Adapter
{
    internal interface IFacebookCollection<T>
    {
        FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar();

        FacebookObjectCollection<T> UnboxCollection(FacebookObjectCollection<FacebookObject> i_Collection);

        Album[] AlbumsToLoad { get; set; }
    }
}
