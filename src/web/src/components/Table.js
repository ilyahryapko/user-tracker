import React from 'react'
import PropTypes from 'prop-types'

export default function Table({ data }) {

  let tableContent = data.map((row, index) => {
    const { userId, timestamp, fromPage, toPage } = row;
    const date = new Date(timestamp);
    const dateTime = `${date.toLocaleDateString()} ${date.toLocaleTimeString()}`;
    return (
      <tr className='table-row' key={index}>
        <td>{dateTime}</td>
        <td>{userId}</td>
        <td>{fromPage}</td>
        <td>{toPage}</td>
      </tr>
    )
  })

  let tableHeader = ['Timestamp', 'User ID', 'Source', 'Destination'].map((name, index) => {
    return <th key={index}>{name}</th>
  })

  return (
    <div>
      <table className='table-log'>
        <thead>
          <tr>{tableHeader}</tr>
        </thead>
        <tbody>
          {tableContent}
        </tbody>
      </table>
    </div>
  )
}

Table.propTypes = {
  data: PropTypes.array.isRequired
}