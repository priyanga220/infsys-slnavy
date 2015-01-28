﻿/*
 * Note.cs    6/16/2008 5:10:39 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight.Modules.Notes.Entities {

    /// <summary>
    /// Represents a simple note object
    /// </summary>
    public class Note {

        /// <summary>
        /// Creates a new instance of <c>Note</c>.
        /// </summary>
        public Note() {
        }

        /// <summary>
        /// Creates a new instance of <c>Note</c>.
        /// </summary>
        /// <param name="noteId">Note ID</param>
        public Note(int noteId) {
            NoteID = noteId;
        }

        /// <summary>
        /// Creates a new instance of <c>Note</c>.
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <param name="title">Title</param>
        public Note(int noteId, string title) : this(noteId) {
            Title = title;
        }

        /// <summary>
        /// Creates a new instance of <c>Note</c>.
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <param name="title">Title</param>
        /// <param name="content">Note Content</param>
        public Note(int noteId, string title, string content) : this(noteId, title) {
            Content = content;
        }

        /// <summary>
        /// Note Identifier.
        /// </summary>
        public int NoteID {
            get;
            set;
        }

        /// <summary>
        /// Note title.
        /// </summary>
        public string Title {
            get;
            set;
        }

        /// <summary>
        /// Note content.
        /// </summary>
        public string Content {
            get;
            set;
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                Note other = obj as Note;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(Note) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// Note object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// Note object to compare against.
        /// </param>
        public bool Equals(Note other) {
            return NoteID == other.NoteID;
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 24 * NoteID;
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
            return String.Format("{0}[NoteID={1},Title={2}]",
                GetType().Name,
                NoteID,
                Title);
        }

        #endregion

    }

}

