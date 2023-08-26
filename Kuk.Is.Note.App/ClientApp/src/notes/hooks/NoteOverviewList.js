import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { NoteClient } from '../clients/NoteClient';

export function NoteOverviewList() {
  const [noteIds, setNoteIds] = useState([]);

  useEffect(() => {
    const noteClient = new NoteClient();
    const loadNoteIds = async () => {
      const noteIds = await noteClient.fetchAllNoteIds();
      setNoteIds(noteIds);
    }

    loadNoteIds();
  }, []);

  return (
    <div>
      <Link to="/notes/new">Create New</Link>
      {noteIds.map(noteId => (
        <div key={noteId}>
          <Link to={`/notes/${noteId}`}>{noteId}</Link>
        </div>
      ))}
    </div>
  );
}