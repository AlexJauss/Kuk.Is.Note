import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { NoteClient } from '../clients/NoteClient';
import { EditNote } from './EditNote';

export function CreateNote() {
  const navigate = useNavigate();

  const handleOnSave = async (content) => {
    const noteClient = new NoteClient();
    await noteClient.createNote(content);
    navigate('/notes');
  }

  return (
    <div>
      <div>
        <Link to="/notes">back</Link>
      </div>

      <EditNote initialContent={""} onSave={handleOnSave} />
    </div>
  );
}