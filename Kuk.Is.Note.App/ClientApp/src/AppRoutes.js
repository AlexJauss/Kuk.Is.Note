import { Home } from "./components/Home";
import { NoteOverviewList } from "./notes/hooks/NoteOverviewList";
import { NoteDetail } from "./notes/hooks/NoteDetail";
import { CreateNote } from "./notes/hooks/CreateNote";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/notes',
    element: <NoteOverviewList />
  },
  {
    path: '/notes/new',
    element: <CreateNote />
  },
  {
    path: '/notes/:noteId',
    element: <NoteDetail />
  }
];

export default AppRoutes;
