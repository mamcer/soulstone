﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 2.0.5.0
// 
namespace Soulstone.SL.SoulstoneService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchResultSet", Namespace="http://schemas.datacontract.org/2004/07/Soulstone.WebUI")]
    public partial class SearchResultSet : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.Generic.Dictionary<int, Soulstone.SL.SoulstoneService.SearchResult> SearchResultsField;
        
        private double SearchSecondsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<int, Soulstone.SL.SoulstoneService.SearchResult> SearchResults {
            get {
                return this.SearchResultsField;
            }
            set {
                if ((object.ReferenceEquals(this.SearchResultsField, value) != true)) {
                    this.SearchResultsField = value;
                    this.RaisePropertyChanged("SearchResults");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SearchSeconds {
            get {
                return this.SearchSecondsField;
            }
            set {
                if ((this.SearchSecondsField.Equals(value) != true)) {
                    this.SearchSecondsField = value;
                    this.RaisePropertyChanged("SearchSeconds");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchResult", Namespace="http://schemas.datacontract.org/2004/07/Soulstone.WebUI")]
    public partial class SearchResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid MusicTrackIdField;
        
        private System.Collections.ObjectModel.ObservableCollection<Soulstone.SL.SoulstoneService.MusicTrackLocation> ResultPathField;
        
        private string TrackStringField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid MusicTrackId {
            get {
                return this.MusicTrackIdField;
            }
            set {
                if ((this.MusicTrackIdField.Equals(value) != true)) {
                    this.MusicTrackIdField = value;
                    this.RaisePropertyChanged("MusicTrackId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<Soulstone.SL.SoulstoneService.MusicTrackLocation> ResultPath {
            get {
                return this.ResultPathField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultPathField, value) != true)) {
                    this.ResultPathField = value;
                    this.RaisePropertyChanged("ResultPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TrackString {
            get {
                return this.TrackStringField;
            }
            set {
                if ((object.ReferenceEquals(this.TrackStringField, value) != true)) {
                    this.TrackStringField = value;
                    this.RaisePropertyChanged("TrackString");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MusicTrack", Namespace="http://schemas.datacontract.org/2004/07/Soulstone.WebUI")]
    public partial class MusicTrack : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AlbumField;
        
        private string ArtistField;
        
        private string GenreField;
        
        private string TitleField;
        
        private string YearField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Album {
            get {
                return this.AlbumField;
            }
            set {
                if ((object.ReferenceEquals(this.AlbumField, value) != true)) {
                    this.AlbumField = value;
                    this.RaisePropertyChanged("Album");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Artist {
            get {
                return this.ArtistField;
            }
            set {
                if ((object.ReferenceEquals(this.ArtistField, value) != true)) {
                    this.ArtistField = value;
                    this.RaisePropertyChanged("Artist");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Genre {
            get {
                return this.GenreField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreField, value) != true)) {
                    this.GenreField = value;
                    this.RaisePropertyChanged("Genre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Year {
            get {
                return this.YearField;
            }
            set {
                if ((object.ReferenceEquals(this.YearField, value) != true)) {
                    this.YearField = value;
                    this.RaisePropertyChanged("Year");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MusicTrackLocation", Namespace="http://schemas.datacontract.org/2004/07/Soulstone.WebUI")]
    public partial struct MusicTrackLocation : System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid hostIdField;
        
        private bool isValidField;
        
        private string pathField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid hostId {
            get {
                return this.hostIdField;
            }
            set {
                if ((this.hostIdField.Equals(value) != true)) {
                    this.hostIdField = value;
                    this.RaisePropertyChanged("hostId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isValid {
            get {
                return this.isValidField;
            }
            set {
                if ((this.isValidField.Equals(value) != true)) {
                    this.isValidField = value;
                    this.RaisePropertyChanged("isValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string path {
            get {
                return this.pathField;
            }
            set {
                if ((object.ReferenceEquals(this.pathField, value) != true)) {
                    this.pathField = value;
                    this.RaisePropertyChanged("path");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SoulstoneService.ISoulstoneService")]
    public interface ISoulstoneService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ISoulstoneService/Search", ReplyAction="http://tempuri.org/ISoulstoneService/SearchResponse")]
        System.IAsyncResult BeginSearch(string album, string artist, string title, int year, string genre, System.AsyncCallback callback, object asyncState);
        
        Soulstone.SL.SoulstoneService.SearchResultSet EndSearch(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ISoulstoneService/GetMusicTrack", ReplyAction="http://tempuri.org/ISoulstoneService/GetMusicTrackResponse")]
        System.IAsyncResult BeginGetMusicTrack(System.Guid musicTrackId, System.AsyncCallback callback, object asyncState);
        
        Soulstone.SL.SoulstoneService.MusicTrack EndGetMusicTrack(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ISoulstoneServiceChannel : Soulstone.SL.SoulstoneService.ISoulstoneService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Soulstone.SL.SoulstoneService.SearchResultSet Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Soulstone.SL.SoulstoneService.SearchResultSet)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetMusicTrackCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetMusicTrackCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Soulstone.SL.SoulstoneService.MusicTrack Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Soulstone.SL.SoulstoneService.MusicTrack)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SoulstoneServiceClient : System.ServiceModel.ClientBase<Soulstone.SL.SoulstoneService.ISoulstoneService>, Soulstone.SL.SoulstoneService.ISoulstoneService {
        
        private BeginOperationDelegate onBeginSearchDelegate;
        
        private EndOperationDelegate onEndSearchDelegate;
        
        private System.Threading.SendOrPostCallback onSearchCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetMusicTrackDelegate;
        
        private EndOperationDelegate onEndGetMusicTrackDelegate;
        
        private System.Threading.SendOrPostCallback onGetMusicTrackCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public SoulstoneServiceClient() {
        }
        
        public SoulstoneServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SoulstoneServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoulstoneServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoulstoneServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<SearchCompletedEventArgs> SearchCompleted;
        
        public event System.EventHandler<GetMusicTrackCompletedEventArgs> GetMusicTrackCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Soulstone.SL.SoulstoneService.ISoulstoneService.BeginSearch(string album, string artist, string title, int year, string genre, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSearch(album, artist, title, year, genre, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Soulstone.SL.SoulstoneService.SearchResultSet Soulstone.SL.SoulstoneService.ISoulstoneService.EndSearch(System.IAsyncResult result) {
            return base.Channel.EndSearch(result);
        }
        
        private System.IAsyncResult OnBeginSearch(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string album = ((string)(inValues[0]));
            string artist = ((string)(inValues[1]));
            string title = ((string)(inValues[2]));
            int year = ((int)(inValues[3]));
            string genre = ((string)(inValues[4]));
            return ((Soulstone.SL.SoulstoneService.ISoulstoneService)(this)).BeginSearch(album, artist, title, year, genre, callback, asyncState);
        }
        
        private object[] OnEndSearch(System.IAsyncResult result) {
            Soulstone.SL.SoulstoneService.SearchResultSet retVal = ((Soulstone.SL.SoulstoneService.ISoulstoneService)(this)).EndSearch(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSearchCompleted(object state) {
            if ((this.SearchCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SearchCompleted(this, new SearchCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SearchAsync(string album, string artist, string title, int year, string genre) {
            this.SearchAsync(album, artist, title, year, genre, null);
        }
        
        public void SearchAsync(string album, string artist, string title, int year, string genre, object userState) {
            if ((this.onBeginSearchDelegate == null)) {
                this.onBeginSearchDelegate = new BeginOperationDelegate(this.OnBeginSearch);
            }
            if ((this.onEndSearchDelegate == null)) {
                this.onEndSearchDelegate = new EndOperationDelegate(this.OnEndSearch);
            }
            if ((this.onSearchCompletedDelegate == null)) {
                this.onSearchCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSearchCompleted);
            }
            base.InvokeAsync(this.onBeginSearchDelegate, new object[] {
                        album,
                        artist,
                        title,
                        year,
                        genre}, this.onEndSearchDelegate, this.onSearchCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Soulstone.SL.SoulstoneService.ISoulstoneService.BeginGetMusicTrack(System.Guid musicTrackId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetMusicTrack(musicTrackId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Soulstone.SL.SoulstoneService.MusicTrack Soulstone.SL.SoulstoneService.ISoulstoneService.EndGetMusicTrack(System.IAsyncResult result) {
            return base.Channel.EndGetMusicTrack(result);
        }
        
        private System.IAsyncResult OnBeginGetMusicTrack(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Guid musicTrackId = ((System.Guid)(inValues[0]));
            return ((Soulstone.SL.SoulstoneService.ISoulstoneService)(this)).BeginGetMusicTrack(musicTrackId, callback, asyncState);
        }
        
        private object[] OnEndGetMusicTrack(System.IAsyncResult result) {
            Soulstone.SL.SoulstoneService.MusicTrack retVal = ((Soulstone.SL.SoulstoneService.ISoulstoneService)(this)).EndGetMusicTrack(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetMusicTrackCompleted(object state) {
            if ((this.GetMusicTrackCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetMusicTrackCompleted(this, new GetMusicTrackCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetMusicTrackAsync(System.Guid musicTrackId) {
            this.GetMusicTrackAsync(musicTrackId, null);
        }
        
        public void GetMusicTrackAsync(System.Guid musicTrackId, object userState) {
            if ((this.onBeginGetMusicTrackDelegate == null)) {
                this.onBeginGetMusicTrackDelegate = new BeginOperationDelegate(this.OnBeginGetMusicTrack);
            }
            if ((this.onEndGetMusicTrackDelegate == null)) {
                this.onEndGetMusicTrackDelegate = new EndOperationDelegate(this.OnEndGetMusicTrack);
            }
            if ((this.onGetMusicTrackCompletedDelegate == null)) {
                this.onGetMusicTrackCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetMusicTrackCompleted);
            }
            base.InvokeAsync(this.onBeginGetMusicTrackDelegate, new object[] {
                        musicTrackId}, this.onEndGetMusicTrackDelegate, this.onGetMusicTrackCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override Soulstone.SL.SoulstoneService.ISoulstoneService CreateChannel() {
            return new SoulstoneServiceClientChannel(this);
        }
        
        private class SoulstoneServiceClientChannel : ChannelBase<Soulstone.SL.SoulstoneService.ISoulstoneService>, Soulstone.SL.SoulstoneService.ISoulstoneService {
            
            public SoulstoneServiceClientChannel(System.ServiceModel.ClientBase<Soulstone.SL.SoulstoneService.ISoulstoneService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginSearch(string album, string artist, string title, int year, string genre, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[5];
                _args[0] = album;
                _args[1] = artist;
                _args[2] = title;
                _args[3] = year;
                _args[4] = genre;
                System.IAsyncResult _result = base.BeginInvoke("Search", _args, callback, asyncState);
                return _result;
            }
            
            public Soulstone.SL.SoulstoneService.SearchResultSet EndSearch(System.IAsyncResult result) {
                object[] _args = new object[0];
                Soulstone.SL.SoulstoneService.SearchResultSet _result = ((Soulstone.SL.SoulstoneService.SearchResultSet)(base.EndInvoke("Search", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetMusicTrack(System.Guid musicTrackId, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = musicTrackId;
                System.IAsyncResult _result = base.BeginInvoke("GetMusicTrack", _args, callback, asyncState);
                return _result;
            }
            
            public Soulstone.SL.SoulstoneService.MusicTrack EndGetMusicTrack(System.IAsyncResult result) {
                object[] _args = new object[0];
                Soulstone.SL.SoulstoneService.MusicTrack _result = ((Soulstone.SL.SoulstoneService.MusicTrack)(base.EndInvoke("GetMusicTrack", _args, result)));
                return _result;
            }
        }
    }
}