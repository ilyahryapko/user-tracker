import React, { useState } from 'react'
import PropTypes from 'prop-types';
//import LinkingButton from './LinkingButton';
import logger from '../services/log.service'
import { useHistory } from 'react-router-dom';

export default function NavigationArea({ links }) {
  const currentWebpage = window.location.pathname

  let [isLoading, setLoading] = useState(false);
  const history = useHistory();

  async function clickHandler(nextPage) {
    try {
      setLoading(prev => !prev);
      await logger.sendLog(currentWebpage, nextPage);
      history.push(nextPage)
    }
    finally {
      setLoading(prev => !prev)
    }
  }

  let buttons = links.map((linkObj, index) => {
    return <button disabled={isLoading} className='btn' key={index} onClick={async () => await clickHandler(linkObj.path)}>{linkObj.text}</button>
  });

  return (
    <div className='navigation-area'>
      {buttons}
    </div>
  )
}

NavigationArea.propTypes = {
  links: PropTypes.array.isRequired
}
