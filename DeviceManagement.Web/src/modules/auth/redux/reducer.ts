import { getType } from 'typesafe-actions';
import { DeepReadonly } from 'utility-types';
import { Authenticate } from './types';
import { loadAuthAsync, AuthenticationAction } from './actions';

const initialState: DeepReadonly<Authenticate> = {
  isAuthenticated: false,
  isFetching: false,
  error: '',
  isAuthed: false,
  username: '',
  name: '',
};

export function authenticationReducer(
  state = initialState,
  action: AuthenticationAction,
) {
  switch (action.type) {
    case getType(loadAuthAsync.success):
      return state;
    default:
      return state;
  }
}