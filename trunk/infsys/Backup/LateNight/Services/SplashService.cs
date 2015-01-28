﻿/*
 * SplashService.cs    6/14/2008 4:38:50 PM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BrettRyan.LateNight.Services;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Service for modules to 
    /// </summary>
    /// <remarks>
    /// I need to figure out how to background load modules before I can have
    /// them interact with the splash screen.
    /// </remarks>
    public class SplashService : ISplashService {

        /// <summary>
        /// Creates a new instance of <c>SplashService</c>.
        /// </summary>
        public SplashService() {
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    SplashService other = obj as SplashService;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(SplashService) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(SplashService) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// SplashService object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// SplashService object to compare against.
        ///// </param>
        //public bool Equals(SplashService other) {
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


        #region ISplashService Members

        public void SetMessage(string message) {
            throw new NotImplementedException();
        }

        #endregion
    }

}
