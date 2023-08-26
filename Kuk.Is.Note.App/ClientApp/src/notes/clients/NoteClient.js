import axios from 'axios';

// TODO: to be moved to base classe folder
class BaseClient {
  constructor(baseUri) {
    this.baseUri = baseUri;
  }

  async get(...uriParts) {
    let result = await this.call('get', uriParts);
    return result.data;
  }

  async post(data, ...uriParts) {
    const result = await this.call('post', uriParts, data);
    return result.data;
  }

  async put(data, ...uriParts) {
    const result = await this.call('put', uriParts, data);
    return result.data;
  }

  async delete(...uriParts) {
    const result = await this.call('delete', uriParts);
    return result.data;
  }

  async call(method, uriParts, data) {
    return await axios({
      method: method,
      url: [this.baseUri, ...uriParts].join('/'),
      data: data,
    });
  }
}

export class NoteClient extends BaseClient {
  constructor() {
    super('/api/note');
  }

  async fetchAllNoteIds() {
    return await this.get();
  }

  async fetchNoteById(noteId) {
    return await this.get(noteId);
  }

  async createNote(content) {
    return await this.post({ content });
  }

  async changeNote(noteId, content) {
    return await this.put({ content }, noteId);
  }

  async deleteNote(noteId) {
    return await this.delete(noteId);
  }
}