﻿/*
 * LateNightShellModel.cs    6/14/2008 4:20:27 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Wpf.Commands;
using Microsoft.Practices.Unity;

using BrettRyan.LateNight.Constants;
using BrettRyan.LateNight.DocumentModel;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Model used for the main visual component (UI).
    /// </summary>
    internal sealed class LateNightShellModel : INotifyPropertyChanged {

        private IUnityContainer container;

        /// <summary>
        /// Creates a new instance of <c>LateNightShellModel</c>.
        /// </summary>
        public LateNightShellModel(IUnityContainer container) {
            this.container = container;

            ShowAboutCommand = new DelegateCommand<object>(DoShowAboutExecuted);
            ExitApplicationCommand = new DelegateCommand<object>(DoExitApplicationExecuted);

            DocumentController = container.Resolve<IDocumentController>(
                ControllerNames.DocumentController);
            SystemDocumentController = container.Resolve<IDocumentController>(
                ControllerNames.SystemDocumentController);

            CloseCurrentDocumentCommand = new DelegateCommand<object>(
                DoCloseCurrentDocument, CanCloseCurrentDocument);

            CloseDocumentCommand = new DelegateCommand<AbstractDocument>(
                DocumentController.CloseDocument);

            DocumentController.DocumentOpened
                += new EventHandler<DataEventArgs<AbstractDocument>>(DoReevaluateCloseCurrentDocumentCommand);
            DocumentController.DocumentClosed
                += new EventHandler<DataEventArgs<AbstractDocument>>(DoReevaluateCloseCurrentDocumentCommand);
        }

        private void DoReevaluateCloseCurrentDocumentCommand(object sender, DataEventArgs<AbstractDocument> e) {
            CloseCurrentDocumentCommand.RaiseCanExecuteChanged();
        }

        private void DoCloseCurrentDocument(object arg) {
            DocumentController.CloseDocument(DocumentController.CurrentDocument);
        }

        private bool CanCloseCurrentDocument(object arg) {
            return DocumentController.CurrentDocument != null;
        }

        /// <summary>
        /// Returns the current instance of the document controller.
        /// </summary>
        public IDocumentController DocumentController {
            get;
            private set;
        }

        /// <summary>
        /// Returns the current instance of the system document controller.
        /// </summary>
        public IDocumentController SystemDocumentController {
            get;
            private set;
        }

        /// <summary>
        /// Command which will open a line-plan as a line-plan editor
        /// </summary>
        public DelegateCommand<object> ShowAboutCommand {
            get;
            private set;
        }

        public DelegateCommand<object> CloseCurrentDocumentCommand {
            get;
            private set;
        }

        public DelegateCommand<AbstractDocument> CloseDocumentCommand {
            get;
            private set;
        }

        public DelegateCommand<object> ExitApplicationCommand {
            get;
            private set;
        }

        private void DoShowAboutExecuted(object param) {
            LateNightAboutView about = new LateNightAboutView();
            about.Owner = App.Current.MainWindow;
            about.DataContext = new LateNightAboutModel(container);
            about.ShowDialog();
        }

        private void DoExitApplicationExecuted(object param) {
            App.Current.Shutdown();
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    LateNightShellModel other = obj as LateNightShellModel;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(LateNightShellModel) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(LateNightShellModel) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// LateNightShellModel object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// LateNightShellModel object to compare against.
        ///// </param>
        //public bool Equals(LateNightShellModel other) {
        //    //TODO: Add Equals implementation
        //    return base.Equals(other);
        //}
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            //TODO: create real implementation for GetHashCode()
            // Implementations should at the least return an exclusive or of
            // all properties (prop1.GetHashCode() ^ prop2.GetHashCode()).
            // Improve this by performing binary shifts for values too large
            // for an integer eg. dbl ^ ((uint)dbl >> 32) where dbl is some
            // double.
            //
            // Sample (NetBeans 6.0 Implementation):
            // int hash = {Num};
            // hash = {Num} * hash + this.intProp;
            // hash = {Num} * hash + this.dblProp ^ ((uint)this.dblProp >> 32);
            // hash = {Num} * hash + this.strProp == null
            //                              ? 0 : this.strProp.GetHashCode();
            // return hash;
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <remarks>
        /// Returns a string representation of this object. This is
        /// formatted as a key property list proceeded by the fully qualified
        /// type name.
        /// </remarks>
        public override string ToString() {
            //return GetType().Name
            //    + "["
            ////  TODO: Add property list to output
            ////        Example: Property=value,Property2=value
            //    + "]"
            //    ;
            return base.ToString();
        }

        #endregion


        #region INotifyPropertyChanged Members

        private event PropertyChangedEventHandler propertyChangedEvent;

        public event PropertyChangedEventHandler PropertyChanged {
            add { propertyChangedEvent += value; }
            remove { propertyChangedEvent -= value; }
        }

        private void OnPropertyChanged(string prop) {
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }

}
