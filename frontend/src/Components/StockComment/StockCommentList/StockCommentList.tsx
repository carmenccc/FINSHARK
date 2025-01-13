import React from "react";
import { CommentGet } from "../../../Models/Comment";
import StockCommentListItem from "../StockCommentListItem/StockCommentListItem";

type Props = {
  comments: CommentGet[] | null | undefined;
};

const StockCommentList = ({ comments }: Props) => {
  return (
    <>
      {comments
        ? comments.map((c) => {
            return <StockCommentListItem comment={c} />;
          })
        : ""}
    </>
  );
};

export default StockCommentList;
