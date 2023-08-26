import React, { useEffect, useState } from 'react';
import { useParams, Link, useNavigate } from 'react-router-dom';
import { NoteClient } from '../clients/NoteClient';
import { EditNote } from './EditNote';

// Shows details of notes and allows to edit
export function NoteDetail() {
  const [editEnabled, setEditEnabled] = useState(false)
  const [noteSummary, setNoteSummary] = useState({});
  const { noteId } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchNoteSummary = async () => {
      const noteClient = new NoteClient();
      const noteSummary = await noteClient.fetchNoteById(noteId);
      setNoteSummary(noteSummary);
    }
    if (!editEnabled) {
      fetchNoteSummary()
    }
  }, [editEnabled, noteId]);

  const handleOnToggleEdit = () => {
    if (editEnabled) {
      setEditEnabled(false);
    }
    else {
      setEditEnabled(true);
    }
  };

  const handleOnSave = async (content) => {
    if (editEnabled && content !== noteSummary.content) {
      const noteClient = new NoteClient();
      await noteClient.changeNote(noteId, content);
    }

    setEditEnabled(false);
  }

  const handleOnDelete = async () => {
    // TODO: add a pop-up and ask for confirmation
    const noteClient = new NoteClient();
    await noteClient.delete(noteId);
    navigate('/notes');
  }

  return (
    <div>
      <div>
        <Link to="/notes">back</Link>
      </div>
      <p>{noteId}</p>
      {(editEnabled
        ? <EditNote initialContent={noteSummary.content} onSave={handleOnSave} />
        : <NoteDisplay content={noteSummary.content} />
      )}
      <div>
        <button onClick={handleOnToggleEdit}>{(editEnabled ? "Cancel" : "Edit")}</button>
        <button onClick={handleOnDelete}>Delete</button>
      </div>
    </div>
  );
}

function NoteDisplay({ content }) {
  return <p>{content}</p>
}