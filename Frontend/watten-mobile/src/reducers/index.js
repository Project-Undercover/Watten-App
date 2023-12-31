import { combineReducers } from "redux";
import authReducer from "./authReducer";
import sessionsReducer from "./sessionsReducer";
import usersReducer from "./usersReducer";
const rootReducer = combineReducers({
  auth: authReducer,
  sessions: sessionsReducer,
  users: usersReducer,
});

export default rootReducer;
