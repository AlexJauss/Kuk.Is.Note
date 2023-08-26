import React, { useState } from 'react';

export function EditNote({ initialContent, onSave }) {
  const [content, setContent] = useState(initialContent);

  const handleOnEditChanged = (event) => {
    setContent(event.target.value);
  };

  return (
    <>
      <input type="text" value={content} onChange={handleOnEditChanged} />
      <button onClick={() => onSave(content)}>Save</button>
    </>
  );
}