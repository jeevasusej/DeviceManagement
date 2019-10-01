import { createAsyncAction, ActionType } from 'typesafe-actions';
import { Authenticate } from './types';

// Create action types
export const AUTH = {
  LOAD_LOGIN_REQUEST: '@@AUTH/LOAD_LOGIN_REQUEST',
  LOAD_LOGIN_SUCCESS: '@@AUTH/LOAD_LOGIN_SUCCESS',
  LOAD_LOGIN_FAILURE: '@@AUTH/LOAD_LOGIN_FAILURE',
};

// Create async action
export const loadAuthAsync = createAsyncAction(
  AUTH.LOAD_LOGIN_REQUEST,
  AUTH.LOAD_LOGIN_SUCCESS,
  AUTH.LOAD_LOGIN_FAILURE,
)<undefined, Authenticate, string>();

export type AuthenticationAction = ActionType<typeof loadAuthAsync>;
